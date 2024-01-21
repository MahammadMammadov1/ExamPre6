using ExamPre6.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Business.Service.Interfaces
{
    public interface ISettingService 
    {
        Task<Setting> GetByIdAsync(int id);
        Task<List<Setting>> GetAlldAsync();
        Task UpdateAsync(Setting setting);
    }
}
