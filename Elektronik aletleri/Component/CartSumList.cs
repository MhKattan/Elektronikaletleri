using DataAccessLayer.Data;
using DataAccessLayer.Dto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Session;

namespace Elektronik_aletleri.Component
{
    public class CartSumList : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CartSumList(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVm = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVm);

        }
        
    }
}
