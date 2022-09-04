using AutoMapper;
using KodlamaIODevs.Application.Features.ProgrammingLanguages.Rules;
using KodlamaIODevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguages.Queries.GetById
{
    public class GetProgrammingLanguageByIdQuery:IRequest<GetProgrammingLanguageByIdDto>
    {
        public int Id { get; set; }
        public class GetProgrammingLanguageByIdQueryHandler : IRequestHandler<GetProgrammingLanguageByIdQuery, GetProgrammingLanguageByIdDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public GetProgrammingLanguageByIdQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<GetProgrammingLanguageByIdDto> Handle(GetProgrammingLanguageByIdQuery request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(request.Id);
                var getProgrammingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);
                var getProgrammingLanguageMapper = _mapper.Map<GetProgrammingLanguageByIdDto>(getProgrammingLanguage);
                return getProgrammingLanguageMapper;
              
            }
        }
    }
}
