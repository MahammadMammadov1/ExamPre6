using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Business.CustomExceptions.Clients
{
    public class ContentTypeExceptions : Exception
    {
        public string Property { get; set; }
        public ContentTypeExceptions()
        {
        }

        public ContentTypeExceptions(string ex ,string? message) : base(message)
        {
            Property = ex;
        }
    }
}
