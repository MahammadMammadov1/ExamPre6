using Microsoft.AspNetCore.Mvc;

namespace ExamPre6.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



    }
}
