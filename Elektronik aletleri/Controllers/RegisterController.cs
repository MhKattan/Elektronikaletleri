using DataAccessLayer.Dto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Elektronik_aletleri.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            Random random = new Random();
            int code = 0;
            code = random.Next(10000, 1000000);
            AppUser appuser = new AppUser()
            {
                FirstName = appUserRegisterDto.FirstName,
                LastName = appUserRegisterDto.LastName,
                UserName = appUserRegisterDto.UserName,
                City = appUserRegisterDto.City,
                Email = appUserRegisterDto.Email,
                

            };
            var result = await _userManager.CreateAsync(appuser, appUserRegisterDto.Password);
            if (result.Succeeded)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("MK Elektronik", "muh.kattan@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", appuser.Email);
                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo) ;
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody= "Kydınız Başarlı bi şekilde Gerçekleşti"+code;
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "MK Elektronik";
                SmtpClient client= new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("muh.kattan@gmail.com", "xygf sfjx sfuz clys");
                client.Send(mimeMessage);
                client.Disconnect(true);

                TempData["Mail"] = appUserRegisterDto.Email;
                
                return RedirectToAction("Index", "ConfirmMail");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
