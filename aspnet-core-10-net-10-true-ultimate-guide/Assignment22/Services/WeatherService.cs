using Assignment20.Models;
using Assignment22.ServiceContracts;

namespace Assignment22.Services
{
    public class WeatherService : IWeatherService
    {
        List<CityWeather> WeatherList { get; }
        public WeatherService()
        {
            WeatherList = new List<CityWeather>
            {
                new CityWeather
                {
                    CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33
                },
                new CityWeather
                {
                    CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60
                },
                new CityWeather
                {
                    CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82
                }
            };
        }
        public CityWeather? GetWeatherByCityCode(string cityCode)
        {
            CityWeather cityWeather = WeatherList.FirstOrDefault(c => c.CityUniqueCode == cityCode);
            return cityWeather;
        }

        public List<CityWeather> GetWeatherDetails()
        {
            return WeatherList;
        }
    }
}
