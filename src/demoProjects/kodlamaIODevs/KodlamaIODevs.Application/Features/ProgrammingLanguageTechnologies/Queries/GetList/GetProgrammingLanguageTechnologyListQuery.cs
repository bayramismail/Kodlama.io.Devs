using AutoMapper;
using Core.Application.Requests;
using KodlamaIODevs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetList
{
    public class GetProgrammingLanguageTechnologyListQuery:IRequest<ProgrammingLanguageTechnologyModel>
    {
        public PageRequest  PageRequest { get; set; }
        public class GetProgrammingLanguageTechnologyListQueryHandler : IRequestHandler<GetProgrammingLanguageTechnologyListQuery, ProgrammingLanguageTechnologyModel>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

            public GetProgrammingLanguageTechnologyListQueryHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
            {
                _mapper = mapper;
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            }

            public async Task<ProgrammingLanguageTechnologyModel> Handle(GetProgrammingLanguageTechnologyListQuery request, CancellationToken cancellationToken)
            {
                var list = await _programmingLanguageTechnologyRepository.GetListAsync(include:p=>
                p.Include(x=>x.ProgrammingLanguage),
                index:request.PageRequest.Page,
                size:request.PageRequest.PageSize);
                var mapper = _mapper.Map<ProgrammingLanguageTechnologyModel>(list);
                return mapper;
            }
        }
    }
}
