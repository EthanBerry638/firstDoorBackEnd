using Microsoft.AspNetCore.Mvc;
using firstDoorBackEnd.Services;
using firstDoorBackEnd.Models;

namespace firstDoorBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CareerJetController : ControllerBase
    {
        private readonly ICareerJetService _careerJetService;

        public CareerJetController(ICareerJetService careerJetService)
        {
            _careerJetService = careerJetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobsAsync(string userIp, string userAgent)
        {
           var jobs = await _careerJetService.GetAllJobsAsync(userIp,userAgent);
           return Ok(jobs);
        }

        public (string, string) GetUserIPAndUserAgent()
        {
            string userIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            string userAgent = HttpContext.Request.Headers.UserAgent.ToString() ?? string.Empty;

            return (userIp, userAgent);
        }
    }
}
