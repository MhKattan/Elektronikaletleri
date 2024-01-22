using BusinessLayer.Common;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Elektronik_aletleri.Controllers
{
    public class PersonelController : Controller
    {
        private readonly IPersonelRepository _personelRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PersonelController(IPersonelRepository personelRepository, IWebHostEnvironment webHostEnvironment)
        {
            _personelRepository = personelRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var per=_personelRepository.GetAll();
            return View(per);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Personel gelen, IFormFile FotoYukle)
        {
            if (FotoYukle != null)
            {
                String filename = Guid.NewGuid().ToString() + Path.GetExtension(FotoYukle.FileName);
                string Image = Path.Combine(_webHostEnvironment.WebRootPath, @"Fotopersonel");
                using (var fileStream = new FileStream(Path.Combine(Image, filename), FileMode.Create))
                {
                    FotoYukle.CopyTo(fileStream);
                    gelen.PersonelPicture = filename;
                }
            }
            else
            {
                gelen.PersonelPicture = "image-not-found.png";
            }
            _personelRepository.Add(gelen);
            _personelRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _personelRepository.GetId(u => u.PersonelId == id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Personel gelen)
        {
            _personelRepository.Update(gelen);
            _personelRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bul = _personelRepository.GetId(u => u.PersonelId == id);
            return View(bul);
        }
        [HttpPost]
        public IActionResult Delete(Personel gelen)
        {
            _personelRepository.Delete(gelen);
            _personelRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
