using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Models
{
    public class BookDetails
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int YearPublished { get; set; }
    }
}
