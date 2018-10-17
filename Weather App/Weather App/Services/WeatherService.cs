using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Weather_App.Interfaces;
using Weather_App.Models;
using Weather_App.ViewModels;

namespace Weather_App.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration _configuration;
        private readonly IApiInteractionService _apiInteractionService;

        public WeatherService(IConfiguration configuration, IApiInteractionService apiInteractionService)
        {
            _configuration = configuration;
            _apiInteractionService = apiInteractionService;
        }

        private const string BaseUrlAddres = "http://api.openweathermap.org";


        public async Task<WeatherViewModel> LoadCurrentWeatherDataForCity(string cityData)
        {
            var zipCode = CheckIfZipCode(cityData);
            var paramtetesUrl = zipCode != 0
                ? $"/data/2.5/weather?zip={zipCode}&appid={_configuration["OpenWeatherApiKey"]}&units=metric"
                : $"/data/2.5/weather?q={cityData}&appid={_configuration["OpenWeatherApiKey"]}&units=metric";
            var weatherResult =
                await _apiInteractionService.GetExternalApiResult<CurrentWeatherResponse>(BaseUrlAddres, paramtetesUrl);

            var result = new WeatherViewModel
            {
                CityName = weatherResult.Name,
                WeatherDetails = new List<WeatherDetailsViewModel>
                {
                    new WeatherDetailsViewModel
                    {
                        Humidity = weatherResult.MainData.Humidity,
                        Temperature = weatherResult.MainData.Temperature,
                        WindSpeed = weatherResult.WindData.Speed,
                        CalculationDate = DateTime.Now
                    }
                }
            };

            return result;
        }

        public async Task<WeatherViewModel> LoadForecastedWeatherDataForCity(string cityData)
        {
            var zipCode = CheckIfZipCode(cityData);
            var paramtetesUrl = zipCode != 0
                ? $"/data/2.5/forecast?zip={zipCode}&appid={_configuration["OpenWeatherApiKey"]}&units=metric"
                : $"/data/2.5/forecast?q={cityData}&appid={_configuration["OpenWeatherApiKey"]}&units=metric";

            var rawWeather =
                await _apiInteractionService.GetExternalApiResult<ForecastedWeatherResponse>(BaseUrlAddres,
                    paramtetesUrl);
            var result = new WeatherViewModel
            {
                CityName = rawWeather.CityInfo.Name,
                WeatherDetails = rawWeather.WeatherDataList.GroupBy(c => c.CurrentDate.Date).Select(c =>
                    new WeatherDetailsViewModel
                    {
                        Humidity = c.Average(v => v.MainData.Humidity),
                        Temperature = c.Average(v => v.MainData.Temperature),
                        WindSpeed = c.Average(v => v.WindData.Speed),
                        CalculationDate = c.Key.Date
                    })
            };
            return result;
        }

        private static int CheckIfZipCode(string zip)
        {
            var zipParsingResult = int.TryParse(zip, out var zipCode);
            return zipParsingResult ? zipCode : 0;
        }
    }
}