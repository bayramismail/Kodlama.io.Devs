using AutoMapper;
using KodlamaIODevs.Application.Services.Repositories;
using KodlamaIODevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguageTechnologies.Commands.Create
{
    public class CreateProgrammingLanguageTechnologyCommand : IRequest<CreatedProgrammingLanguageTechnologyDto>
    {
        public int ProgramingLanguageId { get; set; }
        public string Name { get; set; }
        public class CreateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommand, CreatedProgrammingLanguageTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

            public CreateProgrammingLanguageTechnologyCommandHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
            {
                _mapper = mapper;
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            }

            public async Task<CreatedProgrammingLanguageTechnologyDto> Handle(CreateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);

                var entity = await _programmingLanguageTechnologyRepository.AddAsync(programmingLanguageTechnology);
                var mapper = _mapper.Map<CreatedProgrammingLanguageTechnologyDto>(entity);
                return mapper;
            }
        }
    }
}
