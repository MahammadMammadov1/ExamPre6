using ExamPre6.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Core.Models
{
    public class Client : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 50)]   
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string City { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Description { get; set; }
        

        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
    }
}
