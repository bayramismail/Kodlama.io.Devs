using AutoMapper;
using KodlamaIODevs.Application.Features.ProgrammingLanguages.Rules;
using KodlamaIODevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguages.Commands.Delete
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeleteProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.WillBeCheckedBeforeDeleting(request.Id);
                var programmingLanguageEntity = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);
                var deleteProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(programmingLanguageEntity);
                var deleteProgrammingLanguageMapper = _mapper.Map<DeleteProgrammingLanguageDto>(deleteProgrammingLanguage);
                return deleteProgrammingLanguageMapper;
            }
        }
    }
}
