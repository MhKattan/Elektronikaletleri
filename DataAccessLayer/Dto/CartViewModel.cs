using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
