using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string PersonelPicture { get; set; } = string.Empty;
        public string PersonelName { get; set; }=string.Empty;
        public string PersonelSurname {  get; set; }=string.Empty;
        public string PersonelMail {  get; set; }=string.Empty;
        public string Password {  get; set; }=string.Empty;
        [NotMapped]
        public IFormFile? FotoYukle { get; set; }

    }
}
