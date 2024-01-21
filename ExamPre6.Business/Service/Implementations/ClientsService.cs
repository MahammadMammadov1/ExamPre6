using ExamPre6.Business.CustomExceptions.Clients;
using ExamPre6.Business.Service.Interfaces;
using ExamPre6.Core.Models;
using ExamPre6.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Business.Service.Implementations
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IWebHostEnvironment _env;

        public ClientsService(IClientsRepository clientsRepository,IWebHostEnvironment env)
        {
            _clientsRepository = clientsRepository;
            _env = env;
        }
        public async Task CreateAsync(Client client)
        {
            if(client.FormFile != null)
            {
                if(client.FormFile.ContentType != "image/png" &&  client.FormFile.ContentType != "image/jpeg")
                {
                    throw new ContentTypeExceptions("FormFile", "file must be png or jpeg file");
                }
                if(client.FormFile.Length > 2097156)
                {
                    throw new FileLengthExceptions("FormFile", "file must be less than 2 mb ");
                }

                client.ImageUrl = Helper.Helper.SaveFile(_env.WebRootPath,"Uploads/Clients", client.FormFile);
            }
            else
            {
                throw new ImageFileRequiredExceptions("FormFile", "image file is required ");
            }
            await _clientsRepository.CreateAsync(client);

            client.CreatedTime = DateTime.UtcNow.AddHours(4);
            client.UpdatedTime = DateTime.UtcNow.AddHours(4);

            await _clientsRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _clientsRepository.GetByIdAsync(x=>x.Id == id);
            if(client == null) throw new ClientNotFoundException();

            string oldPatch = Path.Combine(_env.WebRootPath, "Uploads/Clients", client.ImageUrl);
            if (File.Exists(oldPatch))
            {
                File.Delete(oldPatch);
            }
            _clientsRepository.DeleteAsync(client);
            await _clientsRepository.CommitAsync();
        }

        public Task<List<Client>> GetAllAsync()
        {
            return _clientsRepository.GetAllAsync();
        }

        public Task<Client> GetByIdAsync(int id)
        {
            return _clientsRepository.GetByIdAsync(x=>x.Id == id);
        }

        public async Task SoftDelete(int id)
        {
            var client = await _clientsRepository.GetByIdAsync(x => x.Id == id);
            if (client == null) throw new ClientNotFoundException();
            client.IsDeleted = !client.IsDeleted;
            client.UpdatedTime = DateTime.UtcNow.AddHours(4);

            await _clientsRepository.CommitAsync();

        }

        public async Task UpdateAsync(Client client)
        {
            var existClient = await _clientsRepository.GetByIdAsync(x => x.Id == client.Id);
            if (existClient == null) throw new ClientNotFoundException();

            if (client.FormFile != null)
            {
                if (client.FormFile.ContentType != "image/png" && client.FormFile.ContentType != "image/jpeg")
                {
                    throw new ContentTypeExceptions("FormFile", "file must be png or jpeg file");
                }
                if (client.FormFile.Length > 2097156)
                {
                    throw new FileLengthExceptions("FormFile", "file must be less than 2 mb");
                }

                //Helper.Helper.Remove(_env.WebRootPath,"Uploads/Clients", existClient.ImageUrl);

                string oldPatch = Path.Combine(_env.WebRootPath, "Uploads/Clients", existClient.ImageUrl);
                if (File.Exists(oldPatch))
                {
                    File.Delete(oldPatch);
                }

                existClient.ImageUrl = Helper.Helper.SaveFile(_env.WebRootPath,"Uploads/Clients", client.FormFile);
            }

            existClient.FullName = client.FullName; 
            existClient.City = client.City;
            existClient.UpdatedTime = DateTime.UtcNow.AddHours(4);
            existClient.Description = client.Description;

            await _clientsRepository.CommitAsync();
        }
    }
}
