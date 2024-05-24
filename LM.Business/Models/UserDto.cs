using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string UserName { get; set; }
    }
}
