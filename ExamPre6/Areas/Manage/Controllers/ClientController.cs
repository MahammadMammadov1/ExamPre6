using ExamPre6.Business.CustomExceptions.Clients;
using ExamPre6.Business.Service.Interfaces;
using ExamPre6.Core.Models;
using ExamPre6.Data.DAL;
using ExamPre6.PaginatedList;
using Microsoft.AspNetCore.Mvc;

namespace ExamPre6.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ClientController : Controller
    {
        private readonly IClientsService _clientsService;
		private readonly AppDbContext _appDb;

		public ClientController(IClientsService clientsService,AppDbContext appDb)
        {
            _clientsService = clientsService;
			_appDb = appDb;
		}
        public async Task<IActionResult> Index(int page =1)
        {
            var query = _appDb.Clients.AsQueryable();
            PaginatedList<Client> clients = new PaginatedList<Client>(query.Skip((page - 1) * 2).Take(2).ToList(), page, query.ToList().Count, 2);
            if (page > clients.TotalCount)
            {
                page = 1;
                clients = new PaginatedList<Client>(query.Skip((page - 1) * 2).Take(2).ToList(), page, query.ToList().Count, 2);
            }
            //var clients = await _clientsService.GetAllAsync();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {

            if (!ModelState.IsValid) return View();

            try
            {
                await _clientsService.CreateAsync(client);
            }
            catch (ContentTypeExceptions ex)
            {

                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (FileLengthExceptions ex)
            {

                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (ImageFileRequiredExceptions ex)
            {

                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (ClientNotFoundException)
            {

                return View("Error");
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = await _clientsService.GetByIdAsync(id);
            if (client == null) return View("Error");
            return View(client);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Client client)
        {

            if (!ModelState.IsValid) return View(client);

            try
            {
                await _clientsService.UpdateAsync(client);
            }
            catch (ContentTypeExceptions ex)
            {

                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (FileLengthExceptions ex)
            {

                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (ImageFileRequiredExceptions ex)
            {

                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (ClientNotFoundException)
            {

                return View("Error");
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var client = await _clientsService.GetByIdAsync(id);
            if (client == null) return View("Error");
            return View(client);
        }
        [HttpPost]

        public async Task<IActionResult> Delete(Client client)
        {
            try
            {
                await _clientsService.DeleteAsync(client.Id);
            }
            catch (ClientNotFoundException)
            {

                return View("Error");
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _clientsService.SoftDelete(id);
            }
            catch (ClientNotFoundException)
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
