using BusinessLayer.Common;
using DataAccessLayer.Data;
using DataAccessLayer.Repository;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SQLitePCL;

namespace Elektronik_aletleri.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICompanyRepositorycs _companyRepositorycs;
        public ProductController(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment, 
            ICategoryRepository categoryRepository, ICompanyRepositorycs companyRepositorycs)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
            _categoryRepository = categoryRepository;
            _companyRepositorycs = companyRepositorycs;
        }

        public IActionResult Index()
        {
            var pro=_productRepository.GetAll();
            return View(pro);
        }
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> Ctglist=_categoryRepository.GetAll().Select(u=> new SelectListItem
            {
                Text=u.CategoryName,
                Value=u.CategoryId.ToString(),
            });
            ViewData["Ctglist"]=Ctglist;
            IEnumerable<SelectListItem> Comlist = _companyRepositorycs.GetAll().Select(n => new SelectListItem
            {
                Text = n.CompanyName,
                Value = n.CompanyId.ToString(),
            });
            ViewData["Comlist"]= Comlist;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product gelen, IFormFile ResimYukle)
        {
            if (ResimYukle != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(ResimYukle.FileName);
                string ImagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"Foto");
                using (var fileStream = new FileStream(Path.Combine(ImagePath, filename), FileMode.Create))
                {
                    ResimYukle.CopyTo(fileStream);
                    gelen.ProductPicture = filename;
                }
            }
            else
            {
                gelen.ProductPicture = "image-not-found.png";
            }
            _productRepository.Add(gelen);
            _productRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            IEnumerable<SelectListItem> Ctglist = _categoryRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.CategoryId.ToString(),
            });
            ViewData["Ctglist"] = Ctglist;
            IEnumerable<SelectListItem> Comlist = _companyRepositorycs.GetAll().Select(n => new SelectListItem
            {
                Text = n.CompanyName,
                Value = n.CompanyId.ToString(),
            });
            ViewData["Comlist"] = Comlist;
            var value=_productRepository.GetId(u=>u.ProductId==id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Product gelen)
        {
            _productRepository.Update(gelen);
            _productRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bul = _productRepository.GetId(u => u.ProductId == id);
            return View(bul);
        }
        [HttpPost]
        public IActionResult Delete(Product gelen)
        {
            _productRepository.Delete(gelen);
            _productRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
