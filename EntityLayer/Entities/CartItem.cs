using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class CartItem
    {
        public long ProductId {  get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public string Image { get; set; }

        public decimal Total
        {
            get { return Quantity * Price; }
        }
        public CartItem() { }
        public CartItem(Product product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            Quantity = 1;
            Price = Convert.ToDecimal(product.Price);
            Image = product.ProductPicture;
        }
    }
}
