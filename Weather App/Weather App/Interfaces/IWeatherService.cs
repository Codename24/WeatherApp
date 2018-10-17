using System.Threading.Tasks;
using Weather_App.ViewModels;

namespace Weather_App.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherViewModel> LoadCurrentWeatherDataForCity(string cityData);

        Task<WeatherViewModel> LoadForecastedWeatherDataForCity(string cityData);
    }
}