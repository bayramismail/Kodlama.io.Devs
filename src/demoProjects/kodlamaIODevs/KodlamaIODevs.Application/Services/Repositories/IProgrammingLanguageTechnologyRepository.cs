using Core.Persistence.Repositories;
using KodlamaIODevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Services.Repositories
{
    public interface IProgrammingLanguageTechnologyRepository : IAsyncRepository<ProgrammingLanguageTechnology>, IRepository<ProgrammingLanguageTechnology>
    {
    }
}
