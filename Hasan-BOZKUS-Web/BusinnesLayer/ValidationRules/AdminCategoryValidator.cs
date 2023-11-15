using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.ValidationRules
{
    public class AdminCategoryValidator : AbstractValidator<Category>
    {
        public AdminCategoryValidator()
        {
            RuleFor(x => x.CategorName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz");
            RuleFor(x => x.CategorName).MaximumLength(50).WithMessage("Kategori adi en fazla 50 karakter olmalıdır");
            RuleFor(x => x.CategorName).MinimumLength(2).WithMessage("Kategori adi en az 2 karakter olmalıdır");
        }
    }
}
