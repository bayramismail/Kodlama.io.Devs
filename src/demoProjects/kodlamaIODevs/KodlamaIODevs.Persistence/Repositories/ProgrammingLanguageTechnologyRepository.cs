using Core.Persistence.Repositories;
using KodlamaIODevs.Application.Services.Repositories;
using KodlamaIODevs.Domain.Entities;
using KodlamaIODevs.Persistence.Contexts;

namespace KodlamaIODevs.Persistence.Repositories
{
    public class ProgrammingLanguageTechnologyRepository : EfRepositoryBase<ProgrammingLanguageTechnology, BaseDbContext>, IProgrammingLanguageTechnologyRepository
    {
        public ProgrammingLanguageTechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
