using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index() //Sondaki parantezlerden indexin method olduğunu anladım. IActionResult Asp.Net ile view dönmesini sağlar.
        {
            return View();
        }
    }
}
