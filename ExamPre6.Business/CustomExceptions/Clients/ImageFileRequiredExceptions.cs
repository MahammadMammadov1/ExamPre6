using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Business.CustomExceptions.Clients
{
    public class ImageFileRequiredExceptions : Exception
    {
        public string Property { get; set; }
        public ImageFileRequiredExceptions()
        {
        }

        public ImageFileRequiredExceptions(string ex, string? message) : base(message)
        {
            Property = ex;
        }
    }
}
