using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Business.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength: 50)]

        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}   

