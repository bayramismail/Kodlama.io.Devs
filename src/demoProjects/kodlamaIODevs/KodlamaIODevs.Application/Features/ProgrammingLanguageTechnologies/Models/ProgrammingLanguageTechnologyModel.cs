using Core.Persistence.Paging;
using KodlamaIODevs.Domain.Entities;

namespace KodlamaIODevs.Application
{
    public class ProgrammingLanguageTechnologyModel:BasePageableModel
    {
        public IList<ProgrammingLanguageTechnologyDto> Items { get; set; }
    }
}