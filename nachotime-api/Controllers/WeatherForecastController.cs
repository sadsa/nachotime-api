using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nachotime_data;

namespace nachotime_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly NachotimeDbContext context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, NachotimeDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var cards = context.Cards.Where(c => c.Id == 1).Include(x => x.Expressions);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}