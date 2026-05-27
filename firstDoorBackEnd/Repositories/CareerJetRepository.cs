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

        public async Task<List<Job>>? GetJobsAsync(string userIp, string userAgent)
        {
            try
            {
                string query = $"?keywords={Uri.EscapeDataString("junior software")}" +
                               $"&location={Uri.EscapeDataString("london")}" +
                               $"&user_ip={Uri.EscapeDataString(userIp)}" +
                               $"&user_agent={Uri.EscapeDataString(userAgent)}";

                var response = await _httpClient.GetFromJsonAsync<CareerJetResponse>(query);

                return response?.Jobs ?? new List<Job>();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
