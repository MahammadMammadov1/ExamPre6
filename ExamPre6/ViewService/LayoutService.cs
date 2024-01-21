using ExamPre6.Business.Service.Interfaces;
using ExamPre6.Core.Models;

namespace ExamPre6.ViewService
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;

        public LayoutService(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public Task<List<Setting>> GetSetting()
        {
            return _settingService.GetAlldAsync();
        }
    }
}
