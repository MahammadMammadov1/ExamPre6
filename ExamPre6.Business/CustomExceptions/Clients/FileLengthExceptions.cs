using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Business.CustomExceptions.Clients
{
    public class FileLengthExceptions : Exception
    {
        public string Property { get; set; }
        public FileLengthExceptions()
        {
        }

        public FileLengthExceptions(string ex, string? message) : base(message)
        {
            Property = ex;
        }
    }
}
