using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Weather_App.Models;
using Weather_App.ViewModels;

namespace Weather_App.Expressions
{
    public static class WeathedModelsExpressions
    {
        public static readonly Expression<Func<CurrentWeatherResponse, WeatherViewModel>>
            CurrentWeatherResponseToWeatherViewModel = model => new WeatherViewModel
            {
                CityName = model.Name,
                WeatherDetails = new List<WeatherDetailsViewModel>
                {
                    new WeatherDetailsViewModel
                    {
                        Humidity = model.MainData.Humidity,
                        Temperature = model.MainData.Temperature,
                        WindSpeed = model.WindData.Speed,
                        CalculationDate = DateTime.Now
                    }
                }
            };

        public static readonly Expression<Func<ForecastedWeatherResponse, WeatherViewModel>>
            ForecastedWeatherResponseToWeatherViewModel =
                model => new WeatherViewModel
                {
                    CityName = model.CityInfo.Name,
                    WeatherDetails = model.WeatherDataList.Select(c =>
                        new WeatherDetailsViewModel
                        {
                            Humidity = c.MainData.Humidity,
                            Temperature = c.MainData.Temperature,
                            WindSpeed = c.WindData.Speed,
                            CalculationDate = c.CurrentDate
                        })
                };
    }
}