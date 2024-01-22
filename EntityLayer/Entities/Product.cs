using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage ="Boş Bırakamazsınız")]
        [StringLength (50, ErrorMessage ="En az {1} karakter uzunluğunda olmalıdır.")]
        public string ProductName { get; set; } = string.Empty;
        [DisplayName("Ürün Açıklaması")]
        [Required(ErrorMessage = "Boş Bırakamazsınız")]
        public string ProductDescription { get; set; }= string.Empty;
        [DisplayName("Ürün Markası")]
        [Required(ErrorMessage = "Boş Bırakamazsınız")]
        public string ProductBrand { get; set; }=string.Empty;
        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Boş Bırakamazsınız")]
        public int? Price { get; set; }
        [DisplayName("Stok")]
        [Required(ErrorMessage = "Boş Bırakamazsınız")]
        public int? Stock { get; set; }
        public string? ProductPicture { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        [NotMapped]
        public IFormFile? ResimYukle { get; set; }
        public virtual List<Sale>? Salelist { get; set; }
    }
}
