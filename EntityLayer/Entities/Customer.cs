using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Boş Bırakamazsınız")]
        public string CustomerName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Boş Bırakamazsınız")]
        public string CustomerSurname { get; set; }= string.Empty;
        [Required(ErrorMessage = "Boş Bırakamazsınız")]
        public string CustomerEmail { get; set; } = string.Empty;
        [Required(ErrorMessage = "Boş Bırakamazsınız")]
        public string Password { get; set; } = string.Empty;
        public virtual List<Sale>? Sales { get; set; }

    }
}
