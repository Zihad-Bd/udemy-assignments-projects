using Assignment20.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment20.ViewComponents
{
    public class WeatherViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather weather)
        {
            return View(weather);
        }
    }
}
