using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Elektronik_aletleri.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var value = TempData["Mail"];
            ViewBag.Mail = value;
            ViewBag.Code=ViewBag.Code;
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(ConfirmMailViewModel gelen)
        {
            var user=await _userManager.FindByEmailAsync(gelen.Email);
            if (user.ConfirmCode == gelen.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Login");

            }
            return View();
        }
    }
}
