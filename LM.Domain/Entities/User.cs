using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string UserName { get; set; }
    }
}
