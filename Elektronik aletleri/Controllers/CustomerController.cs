using BusinessLayer.Common;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elektronik_aletleri.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var cus=_customerRepository.GetAll();
            return View(cus);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (Customer gelen)
        {
            _customerRepository.Add(gelen);
            _customerRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value=_customerRepository.GetId(u=>u.CustomerId==id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Customer gelen)
        {
            _customerRepository.Update(gelen);
            _customerRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bul = _customerRepository.GetId(u=>u.CustomerId== id);
            return View(bul);
        }
        [HttpPost]
        public IActionResult Delete(Customer gelen)
        { 
            _customerRepository.Delete(gelen);
            _customerRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
