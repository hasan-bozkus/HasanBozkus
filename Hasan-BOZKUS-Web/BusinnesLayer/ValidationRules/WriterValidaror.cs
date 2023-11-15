using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.ValidationRules
{
    public class WriterValidaror: AbstractValidator<Writer>
    {
        public WriterValidaror()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("E-Posta adresi boş geçilemez");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("E-posta adresine uygun karakter giriniz");
            RuleFor(x => x.WriterRePassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterRePassword).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı");
            RuleFor(x => x.WriterRePassword).MaximumLength(16).WithMessage("Şifre en fazla 16 karakter olmalı");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterPassword).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı");
            RuleFor(x => x.WriterPassword).MaximumLength(16).WithMessage("Şifre en fazla 16 karakter olmalı");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 2 karakter olmalı");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En fazla 50 karater olmalı");
        }
    }
}
