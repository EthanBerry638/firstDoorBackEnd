using firstDoorBackEnd.Models;
using firstDoorBackEnd.Controllers;
using firstDoorBackEnd.Services;
using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace firstDoorBackEnd.Tests;

public class CareerJetControllerTests
{
    private CareerJetController _careerJetController;
    private Mock<ICareerJetService> mockCareerJetService;
    private HttpContext _httpContext;

    [SetUp]
    public void Setup()
    {
        mockCareerJetService = new Mock<ICareerJetService>();
        _careerJetController = new CareerJetController(mockCareerJetService.Object);
        _httpContext = new DefaultHttpContext();
    }

    [Test]
    public async Task GetAllJobsAsync_ReturnsOkResultWithJobs()
    {
        var jobs = new List<Job>()
        {
            new("software engineer", "microsoft", "london", ".NET developer", "test url")
        };

        mockCareerJetService.Setup(s => s.GetAllJobsAsync("string", "string")).ReturnsAsync(jobs);

        var result = await _careerJetController.GetAllJobsAsync("string", "string");
        var okResult = result as Microsoft.AspNetCore.Mvc.OkObjectResult;


        Assert.IsInstanceOf<OkObjectResult>(result);
        Assert.That(jobs, Is.EqualTo(okResult!.Value));
    }

    [Test]
    public async Task GetAllJobsAsync_ReturnsOkResultWithEmptyList()
    {
        var jobs = new List<Job>();

        mockCareerJetService.Setup(s => s.GetAllJobsAsync("string", "string")).ReturnsAsync(jobs);

        var result = await _careerJetController.GetAllJobsAsync("string", "string");
        var okResult = result as OkObjectResult;

        Assert.IsInstanceOf<OkObjectResult>(result);
        Assert.That(jobs, Is.EqualTo(okResult!.Value));
    }

    [Test]
    public async Task GetUserIPAndUserAgent_ReturnsUserIpAndUserAgent()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Connection.RemoteIpAddress = System.Net.IPAddress.Parse("127.0.0.1");
        httpContext.Request.Headers["User-Agent"] = "Mozilla/5.0";

        _careerJetController.ControllerContext = new ControllerContext()
        {
            HttpContext = httpContext
        };

        var result = _careerJetController.GetUserIPAndUserAgent();

        Assert.That(result.Item1, Is.EqualTo("127.0.0.1"));
        Assert.That(result.Item2, Is.EqualTo("Mozilla/5.0"));
    }

    [Test]
    public async Task GetUserIPAndUserAgent_ReturnsEmptyStrings_WhenValuesAreMissing()
    {

        _httpContext.Connection.RemoteIpAddress = System.Net.IPAddress.Parse("127.0.0.1");
        _httpContext.Request.Headers["User-Agent"] = "Mozilla/5.0";

        _careerJetController.ControllerContext = new ControllerContext()
        {
            HttpContext = _httpContext
        };

        var result = _careerJetController.GetUserIPAndUserAgent();

        Assert.That(result.Item1, Is.EqualTo("127.0.0.1"));
        Assert.That(result.Item2, Is.EqualTo("Mozilla/5.0"));
    }
}