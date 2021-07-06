using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {

        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Lütfen Mail Giriniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen bir Konu Giriniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Girini");
        }

    }
}
