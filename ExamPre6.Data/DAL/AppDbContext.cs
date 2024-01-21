using ExamPre6.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Data.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions dbContext) : base(dbContext) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Setting> Settings{ get; set; }
        public DbSet<AppUser> AppUsers{ get; set; }
    }
}
