using AutoMapper;
using KodlamaIODevs.Application.Features.ProgrammingLanguages.Rules;
using KodlamaIODevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguages.Commands.Update
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdateProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.TheyWillBeCheckedBeforeUpdating(request.Id, request.Name);
                var programmingLanguageEntity = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);
                programmingLanguageEntity.Name = request.Name;
                programmingLanguageEntity.Status = request.Status;
                programmingLanguageEntity.UpdateDate = DateTime.Now;
                var updatedProgrammingLanguageEntity = await _programmingLanguageRepository.UpdateAsync(programmingLanguageEntity);
                var programmingLanguageEntityMapper = _mapper.Map<UpdateProgrammingLanguageDto>(updatedProgrammingLanguageEntity);
                return programmingLanguageEntityMapper;

            }
        }
    }
}
