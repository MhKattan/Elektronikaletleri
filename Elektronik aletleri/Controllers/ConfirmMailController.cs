using Microsoft.AspNetCore.Mvc;

namespace Elektronik_aletleri.Controllers
{
    public class ConfirmMailController : Controller
    {
        public IActionResult Index()
        {
            var value = TempData["Mail"];
            ViewBag.Mail = value;
            ViewBag.Code=ViewBag.Code;
            return View();
        }
    }
}
