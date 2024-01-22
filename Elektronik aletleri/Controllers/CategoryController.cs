using BusinessLayer.Common;
using DataAccessLayer.Repository;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elektronik_aletleri.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var ctg = _categoryRepository.GetAll();
            return View(ctg);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category gelen)
        {
            _categoryRepository.Add(gelen);
            _categoryRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value=_categoryRepository.GetId(u=>u.CategoryId==id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Category gelen)
        {
            _categoryRepository.Update(gelen);
            _categoryRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bul= _categoryRepository.GetId(u=> u.CategoryId==id);
            return View(bul);
        }
        [HttpPost]
        public IActionResult Delete(Category gelen)
        {
            _categoryRepository.Delete(gelen);
            _categoryRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
