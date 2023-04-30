using Microsoft.AspNetCore.Mvc;
using SessionAuth;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        // Check if the user is authenticated
        if (!User.Identity.IsAuthenticated)
        {
            return Unauthorized();
        }

        // Get the weather data
        var weatherData = new WeatherForecast()
        {
            Date = DateTime.Now,
            Summary = "Sunny"
        };

        return Ok(weatherData);
    }
}
