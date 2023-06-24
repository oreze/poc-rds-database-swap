using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRDSDS.API.Data;

namespace PRDSDS.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly AppDbContext _appDBContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        AppDbContext appDbContext)
    {
        _logger = logger;
        _appDBContext = appDbContext;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await _appDBContext.WeatherForecasts.ToListAsync();
    }
}
