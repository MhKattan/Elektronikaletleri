using BusinessLayer.Common;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elektronik_aletleri.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public IActionResult Index()
        {
            var sal=_saleRepository.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sale gelen)
        {
            _saleRepository.Add(gelen);
            _saleRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value=_saleRepository.GetId(u=>u.SaleId==id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Sale gelen)
        {
            _saleRepository.Update(gelen);
            _saleRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bul = _saleRepository.GetId(u=>u.SaleId == id);
            return View(bul);
        }
        [HttpPost]
        public IActionResult Delete(Sale gelen)
        {
            _saleRepository.Delete(gelen);
            _saleRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
