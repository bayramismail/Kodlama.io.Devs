using AutoMapper;
using KodlamaIODevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguageTechnologies.Commands.Update
{
    public class UpdateProgrammingLanguageTechnologyCommand:IRequest<UpdatedProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommand, UpdatedProgrammingLanguageTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

            public UpdateProgrammingLanguageTechnologyCommandHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
            {
                _mapper = mapper;
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            }

            public async Task<UpdatedProgrammingLanguageTechnologyDto> Handle(UpdateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var getData = await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id);
                getData.Name = request.Name;
                getData.ProgrammingLanguageId = request.ProgrammingLanguageId;
                getData.UpdateDate = DateTime.Now;
                var entity = await _programmingLanguageTechnologyRepository.UpdateAsync(getData);
                var mapper = _mapper.Map<UpdatedProgrammingLanguageTechnologyDto>(entity);
                return mapper;
            }
        }
    }
}
