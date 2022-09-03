using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Domain.Entities
{
    /// <summary>
    /// Programlama Dili
    /// </summary>
    public class ProgrammingLanguage:Entity
    {
        public string Name { get; set; }
        public ProgrammingLanguage()
        {

        }

        public ProgrammingLanguage(int id,string name) : base(id)
        {
            Name = name;
        }

        public ProgrammingLanguage(int id,string name, DateTime createDate, DateTime updateDate, bool status) : base(id, createDate, updateDate, status)
        {
            Name=name;
        }
    }
}
