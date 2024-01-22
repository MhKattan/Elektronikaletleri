using BusinessLayer.Common;
using DataAccessLayer.Data;
using Elektronik_aletleri.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Elektronik_aletleri.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context, IProductRepository productRepository)
        {
            _logger = logger;
            _context = context;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var pro= _productRepository.GetAll();
            return View(pro);
        }
        public IActionResult Detay(int id)
        {
            var value = _productRepository.GetId(u => u.ProductId == id);
            return View(value);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
