using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;
using System.Linq;

using System.Web;
using System.Security.Claims;

namespace MyPortfolio.Controllers
{
	public class LogInController : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IActionResult Index()  // Index sayfasına yönlendirme
        {
			return View();
		}
        [HttpPost] //   // Login işlemini yapma
        public async Task<IActionResult> Index(string Email, string Password)
        {
            if (Email == "sumeyye@myportfolio.com" && Password == "123456aA...") //  // Kullanıcı adı ve şifre doğrulaması 
            {
                var claims = new List<Claim>    // Kullanıcı doğrulandı, claim'ler oluşturuluyor
                {
                    new Claim(ClaimTypes.Email, Email)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);  // Kimlik oluşturuluyor
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);   // Kullanıcıyı kimlik doğrulama
                return RedirectToAction("Index", "Statistic");   // Admin ana sayfaya yönlendir
            }
            ViewBag.ErrorMessage = "Hatalı giriş, LogIn sayfasına geri dön";
            return View();
        }

    }
}
