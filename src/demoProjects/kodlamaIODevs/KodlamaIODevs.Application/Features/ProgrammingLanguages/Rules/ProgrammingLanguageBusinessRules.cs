using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using KodlamaIODevs.Application.Features.ProgrammingLanguages.Constants;
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
        /// <summary>
        /// Silmeden önce kontrol edilecek
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task WillBeCheckedBeforeDeleting(int id)
        {
            var entity = await _programmingLanguageRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                throw new BusinessException(ProgrammingLanguageMessages.NoRecordFoundToBeDeleted);
        }
        /// <summary>
        /// Güncellemeden önce kontrol edilecekler
        /// </summary>
        /// <param name="updateProgrammingLanguageDto"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task TheyWillBeCheckedBeforeUpdating(int id ,string name)
        {
            var entityByName = await _programmingLanguageRepository.GetAsync(x => x.Name.ToLower() == name.ToLower());
            if (entityByName != null)
                if (entityByName.Id != id)
                    throw new BusinessException(ProgrammingLanguageMessages.CurrentRecord);
            var entityById = await _programmingLanguageRepository.GetAsync(x => x.Id ==id);
            if (entityById == null)
                throw new BusinessException(ProgrammingLanguageMessages.NoRecordsToBeUpdatedWereFound);
        }
        /// <summary>
        /// İstendiğinde Programlama Dili Bulunmalıdır
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task ProgrammingLanguageShouldExistWhenRequested(int id)
        {
            var result = await _programmingLanguageRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(ProgrammingLanguageMessages.TheRequestedProgrammingLanguageIsNotAvailable);
        }
    }
}
