using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int ConfirmCode {  get; set; }
    }
}
