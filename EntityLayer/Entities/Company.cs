using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Boş Bırakamazsınız")]
        public string CompanyName { get; set;}= string.Empty;
        public virtual List<Product>? Products { get; set; }
    }
}
