using ApplicationLayer;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

        private readonly ILogger<WeatherForecastController> _logger;


        private readonly IWeatherForecastApplicationService _application;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastApplicationService application)
        {
            _logger = logger;

            _application = application;
        }


        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<IEnumerable<WeatherForecastDTO>> Get()
        {
            /* résulat direct
             * 
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }
            )
            .ToArray();
            */

            try
            {
                return Ok(_application.GetWeatherForecastApp().Select(wf => new WeatherForecastDTO
                {
                    Date = wf.Date,
                    TemperatureC = wf.TemperatureC,
                    Summary = wf.Summary

                }));

            }

            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError); }



            /*
            var users = new List<User>();

            users.Add(new User { Nom = "User1", Age = 30 });
            users.Add(new User { Nom = "User2", Age = 40 });

            int a = 5; 
            var tab = users.Where(usr => usr.Age > 30).Select(usr => new { usr.Age, Test="Test" }).ToArray();
            */
        }


    }


}