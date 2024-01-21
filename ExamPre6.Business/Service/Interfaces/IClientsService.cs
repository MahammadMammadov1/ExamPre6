using ExamPre6.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Business.Service.Interfaces
{
    public interface IClientsService
    {
        Task CreateAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<Client> GetByIdAsync(int id);
        Task<List<Client>> GetAllAsync();
    }
}
