using Assignment20.Models;
using Assignment22.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Assignment20.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cityWeathers = _weatherService.GetWeatherDetails();
            return View(cityWeathers);
        }
        [Route("/weather/{cityCode}")]
        public IActionResult Weather([FromRoute] string cityCode)
        {
            CityWeather cityWeather = _weatherService.GetWeatherByCityCode(cityCode);
            if (cityWeather == null)
            {
                return NotFound("The city is not found");
            }
            return View(cityWeather);
        }
    }
}
