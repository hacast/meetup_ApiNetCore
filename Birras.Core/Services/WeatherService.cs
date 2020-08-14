using Birras.Core.Interfaces;
using System;

namespace Birras.Core.Services
{
    public class WeatherService : IWeatherService
    {
        public int GetWeatherByDay(DateTime date)
        {
            //var http = new IHttpClientFactory();


            return new Random().Next(15, 30); ;
        }

    }
}
