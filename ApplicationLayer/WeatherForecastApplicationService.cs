using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2;

namespace ApplicationLayer
{
    public class WeatherForecastApplicationService : IWeatherForecastApplicationService
    {

        private readonly IWeatherForecastDomainService _domain;

        public WeatherForecastApplicationService(IWeatherForecastDomainService domain)
        {
            _domain = domain;

        }


        public List<WeatherForecast> GetWeatherForecastApp()
        {

            return _domain.GetWeatherForecastDomain();    

        }


    }
}
