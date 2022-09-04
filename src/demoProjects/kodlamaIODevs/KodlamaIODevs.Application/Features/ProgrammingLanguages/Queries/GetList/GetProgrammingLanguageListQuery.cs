using AutoMapper;
using Core.Application.Requests;
using KodlamaIODevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguages.Queries.GetList
{
    public class GetProgrammingLanguageListQuery:IRequest<GetProgrammingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetProgrammingLanguageListQueryHandler : IRequestHandler<GetProgrammingLanguageListQuery, GetProgrammingLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public GetProgrammingLanguageListQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<GetProgrammingLanguageListModel> Handle(GetProgrammingLanguageListQuery request, CancellationToken cancellationToken)
            {
                var getProgrammingLanguageList = await _programmingLanguageRepository.GetListAsync();
                var getProgrammingLanguageListModel = _mapper.Map<GetProgrammingLanguageListModel>(getProgrammingLanguageList);
                return getProgrammingLanguageListModel;
            }
        }
    }
}
