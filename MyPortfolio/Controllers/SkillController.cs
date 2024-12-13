using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Entities;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        MyPortfolioContext Context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values=Context.Skills.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        { 
        Context.Skills.Add(skill);
        Context.SaveChanges();
        return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var values = Context.Skills.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        { 
        var value=Context.Skills.Update(skill);
        Context.SaveChanges();
        return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            var value = Context.Skills.Find(id);
            Context.Skills.Remove(value);
            Context.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}
