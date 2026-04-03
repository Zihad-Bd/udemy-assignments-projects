using Assignment18.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment18.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cityWeathers = new List<CityWeather>
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
            return View(cityWeathers);
        }
        [Route("/weather/{cityCode}")]
        public IActionResult Weather([FromRoute] string cityCode)
        {
            List<CityWeather> cityWeathers = new List<CityWeather>
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
            CityWeather cityWeather = cityWeathers.FirstOrDefault(c => c.CityUniqueCode == cityCode);
            if (cityWeather == null)
            {
                return NotFound("The city is not found");
            }
            return View(cityWeather);
        }
    }
}
