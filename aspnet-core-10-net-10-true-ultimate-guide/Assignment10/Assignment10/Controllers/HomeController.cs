using Microsoft.AspNetCore.Mvc;

namespace Assignment10.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        dynamic _accountInfo = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };
        [Route("/")]
        public IActionResult Index()
        {
            return Ok("Welcome to the Best Bank");
        }
        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            return Json(_accountInfo);
        }
        [Route("/account-statement")]
        public IActionResult Statement()
        {
            return File("/file.pdf", "application/pdf");
        }
        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult CurrentBalance()
        {
            if (Request.RouteValues.ContainsKey("accountNumber"))
            {
                bool isValid = int.TryParse(Request.RouteValues["accountNumber"].ToString(), out int accountNumber);
                if (isValid)
                {
                    if (accountNumber == _accountInfo.accountNumber)
                    { 
                        return Ok(_accountInfo.currentBalance); 
                    } 
                }
                return BadRequest("Account Number should be 1001");
            }
            else
            { 
                return NotFound("Account Number should be supplied");
            }
        }
    }
}
