using firstDoorBackEnd.Models;

namespace firstDoorBackEnd.Repositories
{
    public interface ICareerJetRepository
    {
        Task<List<Job>>? GetJobsAsync(string keywords, string location, string userIp, string userAgent);
    }
}
