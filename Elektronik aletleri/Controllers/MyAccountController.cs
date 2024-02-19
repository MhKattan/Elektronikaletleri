using Microsoft.AspNetCore.Mvc;

namespace Elektronik_aletleri.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
