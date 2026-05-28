using firstDoorBackEnd.Models;

namespace firstDoorBackEnd.Repositories
{
    public interface IReedRepository
    {
       Task<List<Job>> GetJobsAsync(string keyword);

       
    }
}
