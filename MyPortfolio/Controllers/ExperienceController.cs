using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfolioContext context=new MyPortfolioContext();
        public IActionResult ExperineceList()
        {
            var values=context.Experiences.ToList();
            return View(values);
        }
		[HttpGet] //Asp.Net'de methodlar HttpGet ve HttpPost olarak 2'ye ayrılır. HttpGet, Sayfa yüklendiğinde çalışır.
		public IActionResult CreateExperience()
		{
			return View();
		}
		[HttpPost] //Burası ise sayfada bir buton çalıştığında çalışır.
		public IActionResult CreateExperience(Experience experience) //Experience sınıfından experience parametresi alır.
		{
			context.Experiences.Add(experience); //Contexte Experiencesin içine parametreden(experinece)dan gönderdiğim değeri ekle.
			context.SaveChanges();//Değişiklikleri kaydet.
			return RedirectToAction("ExperienceList"); //Beni tekrar "ExperienceList'e yönlendir."
		}
		public IActionResult DeleteExperience(int id)
		{
			var value = context.Experiences.Find(id);
			context.Experiences.Remove(value);
			context.SaveChanges();
			return RedirectToAction("ExperienceList");
		}
		[HttpGet]
		public IActionResult UpdateExperience(int id)
		{
			var value=context.Experiences.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateExperience(Experience experience)
		{
			context.Experiences.Update(experience);
			context.SaveChanges();
			return RedirectToAction("ExperienceList");
		}
	}
}
