using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;
using MyPortfolio.Models; // Form Modelini buraya eklemelisiniz.

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {

        MyPortfolioContext context = new MyPortfolioContext();


        // Inbox - Gelen mesajlar
        public IActionResult Inbox()
        {
            var values = context.Messages.ToList();
            return View(values);
        }

        // Message Detail - Mesaj detayını gösterme
        public IActionResult MessageDetail(int id)
        {
            var value = context.Messages.Find(id);
            return View(value);
        }
        // Mesaj gönderme formu
        public IActionResult SendMessage()
        {
            return View();
        }

        // Mesajı veritabanına kaydetme
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (ModelState.IsValid) // Form verilerinin geçerli olup olmadığını kontrol eder.
            {
                context.Messages.Add(message); // Veritabanına ekleme
                context.SaveChanges(); // Değişiklikleri kaydetme
                TempData["MessageSent"] = "Mesajınız başarıyla gönderildi!"; // Gönderim başarılı mesajı
                return RedirectToAction("Inbox"); // Gönderildikten sonra gelen kutusuna yönlendirir
            }

            // Eğer formda hata varsa, mesajı tekrar gösterir.
            return View(message);
        }
        // Okundu durumunu değiştirme
        public IActionResult ChangeIsReadToTrue(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public IActionResult ChangeIsReadToFalse(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        // Mesaj silme
        public IActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
    }
}
