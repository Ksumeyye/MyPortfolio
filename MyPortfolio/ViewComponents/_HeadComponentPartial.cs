using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class _HeadComponentPartial:ViewComponent //ViewComponent adında miras oluşturdum.
    {
        public IViewComponentResult Invoke() //Invoke methodun ismidir.
        {
            return View();
        }
    }
}
