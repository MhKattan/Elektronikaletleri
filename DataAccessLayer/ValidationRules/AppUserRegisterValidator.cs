using DataAccessLayer.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Buraya Boş Bırakmazlar");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Buraya Boş Bırakmazlar");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Buraya Boş Bırakmazlar");
            RuleFor(x => x.City).NotEmpty().WithMessage("Buraya Boş Bırakmazlar");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Buraya Boş Bırakmazlar");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli Bir Mail adresi Giriniz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Buraya Boş Bırakmazlar");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Buraya Boş Bırakmazlar");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Buraya Boş Bırakmazlar");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Buraya Boş Bırakmazlar");
            RuleFor(x => x.FirstName).MaximumLength(30).WithMessage("En Fazla 30 Karaktar Gİrebilirsiniz");
            RuleFor(x => x.FirstName).MinimumLength(5).WithMessage("En az 5 Karaktar Gİrebilirsiniz");
            RuleFor(x => x.Password).MinimumLength(7).WithMessage("En az 7 Karaktar Gİrebilirsiniz");
            RuleFor(x => x.Password).MaximumLength(16).WithMessage("En Fazla 16 Karaktar Gİrebilirsiniz");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Parolalarınız Eşleşmiyor");
        }
    }
}
