using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2;

namespace DomainLayer
{
    public interface IWeatherForecastDomainService
    {
        public List<WeatherForecast> GetWeatherForecastDomain();


    }
}
