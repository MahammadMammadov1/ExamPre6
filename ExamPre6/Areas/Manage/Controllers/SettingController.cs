using ExamPre6.Business.CustomExceptions.Setting;
using ExamPre6.Business.Service.Interfaces;
using ExamPre6.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamPre6.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<IActionResult> Index()
        {
            var setting = await _settingService.GetAlldAsync();
            return View(setting);
        }

        public async Task<IActionResult> Update(int id)
        {
            var exist = await _settingService.GetByIdAsync(id);
            if (exist == null) return View("Error");
            return View(exist);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Setting setting)
        {
            if(!ModelState.IsValid) return View();
            try
            {
                await _settingService.UpdateAsync(setting);
            }
            catch (SettingNotFoundException)
            {

                return View("Error");
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
