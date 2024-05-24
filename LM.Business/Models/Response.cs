using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Models
{
    public class Response
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
    }
}
