using CrossCutting;
using InfrastructureLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2;



namespace DomainLayer
{
    public class WeatherForecastDomainService : IWeatherForecastDomainService
    {

        private readonly IWeatherForecastRepository _repository;


        public WeatherForecastDomainService(IWeatherForecastRepository repository)
        {
            _repository = repository;

        }


        public List<WeatherForecast> GetWeatherForecastDomain()
        {
            //check data 

            using var myActivity = Telemetry.MyActivitySource.StartActivity("GetWeatherForecastDomain");


            try
            {
                return
                _repository.GetWeatherForecastRepo();
            }
            catch (Exception e)
            {
                //throw new DomainException("Pb de récupération de la météo"); 
            }

            return new List<WeatherForecast>();
        }



    }
}
