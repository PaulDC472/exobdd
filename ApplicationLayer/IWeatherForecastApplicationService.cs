using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2;

namespace ApplicationLayer
{
    public interface IWeatherForecastApplicationService
    {
        public List<WeatherForecast> GetWeatherForecastApp();

    }
}
