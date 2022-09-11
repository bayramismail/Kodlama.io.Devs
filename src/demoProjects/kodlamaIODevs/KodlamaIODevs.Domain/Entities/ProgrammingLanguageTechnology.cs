using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Domain.Entities
{
    public class ProgrammingLanguageTechnology:Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public ProgrammingLanguageTechnology()
        {
            ProgrammingLanguage = new ProgrammingLanguage();
        }

        public ProgrammingLanguageTechnology(int id,int programingLanguageId, string name):base(id)
        {
            ProgrammingLanguageId = programingLanguageId;
            Name = name;
            
        }
        public ProgrammingLanguageTechnology(int id, int programingLanguageId, string name,DateTime createDate,DateTime updateDate,bool status) : base(id,createDate,updateDate,status)
        {
            ProgrammingLanguageId = programingLanguageId;
            Name = name;
            
        }
    }
}
