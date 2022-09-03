using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
        public Entity()
        {
        }

        public Entity(int id) : this()
        {
            Id = id;
        }
        public Entity(int id, DateTime createDate, DateTime updateDate, bool status) : this(id)
        {
            CreateDate = createDate;
            UpdateDate = updateDate;
            Status = status;
        }
    }
}
