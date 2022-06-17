using CrossCutting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2;

namespace InfrastructureLayer
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public List<WeatherForecast> GetWeatherForecastRepo()
        {


            using var myActivity = Telemetry.MyActivitySource.StartActivity("GetWeatherForecastRepository");


            myActivity?.AddEvent(new("Appel GetWeatherForecastRepository"));

            // exemple si erreur
            myActivity.SetStatus(ActivityStatusCode.Error, "Something bad happened!");


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }
               )
               .ToList();



        }
    }
}
