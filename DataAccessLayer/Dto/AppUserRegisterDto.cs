using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto
{
    public class AppUserRegisterDto
    {
        [Display(Name ="Adınız")]
        [Required(ErrorMessage ="Adınız Boş Geçemezsiniz")]
        public string FirstName { get; set; }
        [Display(Name = "SoyAdınız")]
        [Required(ErrorMessage = "SoyAdınız Boş Geçemezsiniz")]
        public string LastName { get; set; }
        [Display(Name = "Kullancı Adını")]
        [Required(ErrorMessage = "Kullancı Boş Geçemezsiniz")]
        public string UserName { get; set; }
        [Display(Name = "Şehir Girin")]
        [Required(ErrorMessage = "Şehir Boş Geçemezsiniz")]
        public string City { get; set; }
        [Display(Name = "Mail Girin")]
        [Required(ErrorMessage = "Mail Boş Geçemezsiniz")]
        public string Email { get; set; }
        [Display(Name = "Telefon Girin")]
        [Required(ErrorMessage = "Telefon Boş Geçemezsiniz")]
        public string Phone { get; set; }
        [Display(Name = "Şifre Girin")]
        [Required(ErrorMessage = "Şifre Boş Geçemezsiniz")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
