using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.ValidationRules
{
    public class AppUserValidator : AbstractValidator<AppUser>
    {
        public AppUserValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad ve soyad boş geçilemez");
            RuleFor(x => x.NameSurname).MinimumLength(2).WithMessage("En az 2 karakter olmalı");
            RuleFor(x => x.NameSurname).MaximumLength(50).WithMessage("En fazla 50 karater olmalı");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta adresi boş geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("E-posta adresine uygun karakter giriniz");
            RuleFor(x => x.PasswordHash).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.PasswordHash).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı");
            RuleFor(x => x.PasswordHash).MaximumLength(16).WithMessage("Şifre en fazla 16 karakter olmalı");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("En az 2 karakter olmalı");
            RuleFor(x => x.UserName).MaximumLength(25).WithMessage("En fazla 50 karater olmalı");
        }

    }
}
