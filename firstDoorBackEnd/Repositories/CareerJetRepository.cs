using firstDoorBackEnd.Exceptions;
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

        public async Task<List<Job>> GetAllJobsAsync(string userIp, string userAgent)
        {
            string query = $"v4/query?keywords={Uri.EscapeDataString("junior software")}" +
                           $"&location={Uri.EscapeDataString("london")}" +
                           $"&user_ip={Uri.EscapeDataString(userIp)}" +
                           $"&user_agent={Uri.EscapeDataString(userAgent)}";

            HttpResponseMessage response = await _httpClient.GetAsync(query);

            if (response.IsSuccessStatusCode)
            {
                List<Job> jobs = new List<Job>();
                var jobResponse = await response.Content.ReadFromJsonAsync<CareerJetResponse>();

                for (int i = 0; i < jobResponse.jobs.Count; i++)
                {
                    var job = ConvertToJob(jobResponse!.jobs![i]);
                    jobs.Add(job);
                }

                return jobs;
            }


            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorDetails = await response.Content.ReadFromJsonAsync<CareerJetResponse>();

                throw new CareerJetBadRequestException(errorDetails?.message!);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                throw new CareerJetForbiddenException("The API key or credentials provided are invalid");
            }

            return new List<Job>();
        }

        private Job ConvertToJob(CareerJetJob careerJetJob)
        {
            return new Job(
                careerJetJob.Title ?? string.Empty,
                careerJetJob.Company ?? string.Empty,
                careerJetJob.Locations ?? string.Empty,
                careerJetJob.Description ?? string.Empty,
                careerJetJob.Url ?? string.Empty
            );
        }
    }
}
