using ExamPre6.Business.Service.Interfaces;
using ExamPre6.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamPre6.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientsRepository _clientsRepository;

        public HomeController(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }


        public async Task<IActionResult> Index()
        {
            var client = await _clientsRepository.GetAllAsync(x => x.IsDeleted != true);
            return View(client);
        }

      
    }
}