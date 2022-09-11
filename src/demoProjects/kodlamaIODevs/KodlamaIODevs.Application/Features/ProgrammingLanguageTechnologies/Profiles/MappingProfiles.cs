using AutoMapper;
using Core.Persistence.Paging;
using KodlamaIODevs.Application.Features.ProgrammingLanguageTechnologies.Commands.Create;
using KodlamaIODevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, CreatedProgrammingLanguageTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, DeletedProgrammingLanguageTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, UpdatedProgrammingLanguageTechnologyDto>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguageTechnology>, ProgrammingLanguageTechnologyModel>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyDto>()
                .ForMember(x => x.ProgrammingLanguageName, opt => opt.MapFrom(x => x.ProgrammingLanguage.Name))
                .ReverseMap();
        }
    }
}
