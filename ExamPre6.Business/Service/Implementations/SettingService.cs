using ExamPre6.Business.CustomExceptions.Setting;
using ExamPre6.Business.Service.Interfaces;
using ExamPre6.Core.Models;
using ExamPre6.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Business.Service.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<List<Setting>> GetAlldAsync()
        {
            return await _settingRepository.GetAllAsync();
        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            return await _settingRepository.GetByIdAsync(x=>x.Id == id);
        }

        public async Task UpdateAsync(Setting setting)
        {
            var exist = await _settingRepository.GetByIdAsync(x=>x.Id == setting.Id);
            if (exist == null) throw new SettingNotFoundException();

            exist.Value = setting.Value;
            exist.UpdatedTime = DateTime.UtcNow.AddHours(4);

            await _settingRepository.CommitAsync();
        }
    }
}
