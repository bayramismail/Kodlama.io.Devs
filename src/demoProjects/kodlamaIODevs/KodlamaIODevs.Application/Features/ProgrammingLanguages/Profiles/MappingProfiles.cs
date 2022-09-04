using AutoMapper;
using Core.Persistence.Paging;
using KodlamaIODevs.Application.Features.ProgrammingLanguages.Commands.Create;
using KodlamaIODevs.Application.Features.ProgrammingLanguages.Commands.Delete;
using KodlamaIODevs.Application.Features.ProgrammingLanguages.Commands.Update;
using KodlamaIODevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
                   CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, GetProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, GetProgrammingLanguageListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, GetProgrammingLanguageByIdDto>().ReverseMap();
        }
    }
}
