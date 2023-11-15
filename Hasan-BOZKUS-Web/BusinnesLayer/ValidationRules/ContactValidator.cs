using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactUserName).NotEmpty().WithMessage("Ad boş geçilemez.");
            RuleFor(x => x.ContactUserName).MinimumLength(2).WithMessage("Ad 2 harften az olamaz.");
            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Mail Adresi boş geçilemez.");
            RuleFor(x => x.ContactMail).EmailAddress().WithMessage("Lütfen geçerli bir E-Mail adresi giriniz.");
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("Mesaj boş geçilemez.");
            RuleFor(x => x.ContactMessage).MinimumLength(2).WithMessage("Mesajınız en az 5 harften oluşmalıdır.");
        }
    }
}
