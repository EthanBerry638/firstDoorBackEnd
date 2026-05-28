using firstDoorBackEnd.Models;
using System.Net.Http.Headers;
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