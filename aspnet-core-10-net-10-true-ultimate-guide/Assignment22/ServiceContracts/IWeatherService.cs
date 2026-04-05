using Assignment20.Models;

namespace Assignment22.ServiceContracts
{
    public interface IWeatherService
    {
        List<CityWeather> GetWeatherDetails();
        CityWeather? GetWeatherByCityCode(string CityCode);
    }
}
