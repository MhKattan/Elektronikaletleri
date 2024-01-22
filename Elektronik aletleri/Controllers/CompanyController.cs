using BusinessLayer.Common;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elektronik_aletleri.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepositorycs _companyRepositorycs;

        public CompanyController(ICompanyRepositorycs companyRepositorycs)
        {
            _companyRepositorycs = companyRepositorycs;
        }

        public IActionResult Index()
        {
            var com=_companyRepositorycs.GetAll();
            return View(com);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company gelen)
        {
            _companyRepositorycs.Add(gelen);
            _companyRepositorycs.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value=_companyRepositorycs.GetId(u=>u.CompanyId==id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Company gelen)
        {
            _companyRepositorycs.Update(gelen);
            _companyRepositorycs.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bul = _companyRepositorycs.GetId(u=> u.CompanyId==id);
            return View(bul);
        }
        [HttpPost]
        public IActionResult Delete(Company gelen)
        {
            _companyRepositorycs.Delete(gelen);
            _companyRepositorycs.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
