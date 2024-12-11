using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class MyProfileController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.MyProfiles.ToList();
            return View(values);
        }
		[HttpGet]
		public IActionResult CreateMyProfile()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateMyProfile(MyProfile myProfile)
		{
			context.MyProfiles.Add(myProfile);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
        public IActionResult UpdateMyProfile(int id)
        {
            var value = context.MyProfiles.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateMyProfile(MyProfile myProfile)
        {
            context.MyProfiles.Update(myProfile);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
