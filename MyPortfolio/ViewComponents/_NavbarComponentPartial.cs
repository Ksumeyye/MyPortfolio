using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents
{
    public class _NavbarComponentPartial:ViewComponent
    {
        MyPortfolioContext context=new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.todolistCount = context.ToDoLists.Where(x => x.Status == false).Count(); //Henüz yapılmamış işlemlerin sayısını bana bildirir.
            var values=context.ToDoLists.Where(x=>x.Status==false).ToList(); //Henüz yapılmamış işlemleri bana listeler.
            return View(values);
        }
    }
}
