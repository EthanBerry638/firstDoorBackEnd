using firstDoorBackEnd.Models;
using firstDoorBackEnd.Repositories;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
namespace firstDoorBackEnd.Services
{
    public class ReedService : IReedService
    {
        private readonly IReedRepository _repository;

        public ReedService(IReedRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Job>> GetJobsAsync(string keyword, string location)
        {
            return _repository.GetJobsAsync(keyword, location);
        }
    }

}