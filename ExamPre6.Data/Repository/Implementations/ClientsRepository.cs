using ExamPre6.Core.Models;
using ExamPre6.Core.Repository.Interfaces;
using ExamPre6.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Data.Repository.Implementations
{
    public class ClientsRepository : GenericRepository<Client>, IClientsRepository
    {
        public ClientsRepository(AppDbContext appDb) : base(appDb)
        {
        }
    }
}
