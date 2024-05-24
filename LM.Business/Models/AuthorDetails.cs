using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Models
{
    public class AuthorDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class AuthorIdInput
    {
        public Guid AuthorId { get; set; }
    }

}
