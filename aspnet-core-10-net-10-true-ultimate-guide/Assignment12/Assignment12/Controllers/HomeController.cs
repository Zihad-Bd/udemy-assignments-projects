using Assignment12.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment12.Controllers
{
    public class HomeController : Controller
    {
        [Route("/order")]
        public IActionResult Index([Bind("OrderDate", "InvoicePrice", "Products")] Order order)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorList = new List<string>();
                errorList = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                string errors = string.Join("\n", errorList);
                return BadRequest(errors);
            }
            return Json(order.OrderNo);
        }
    }
}
