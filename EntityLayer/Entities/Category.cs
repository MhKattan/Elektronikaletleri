using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Boş Bırakamazsınız")]
        public string CategoryName { get; set; } = string.Empty;
        public virtual List<Product>? Products { get; set; }
    }
}
