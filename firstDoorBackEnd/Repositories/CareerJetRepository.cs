using firstDoorBackEnd.Models;

namespace firstDoorBackEnd.Repositories
{
    public class CareerJetRepository : ICareerJetRepository
    {
        private readonly HttpClient _httpClient;

        public CareerJetRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<Job>>? GetJobsAsync()
        {
            return null;
        }
    }
}
