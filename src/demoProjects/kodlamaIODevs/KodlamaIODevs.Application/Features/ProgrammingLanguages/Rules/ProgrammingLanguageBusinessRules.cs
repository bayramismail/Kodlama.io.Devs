using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using KodlamaIODevs.Application.Services.Repositories;
using KodlamaIODevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }
        /// <summary>
        /// Mevcut Programlama adı var
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name.ToLower() == name.ToLower());
            if (result.Items.Any()) throw new BusinessException("Programming language name exists.");
        }
    }
}
