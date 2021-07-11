using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
       public MessageValidator()
        {
            RuleFor(x => x.ReciverMail).NotEmpty().WithMessage("Mail bos girilimez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu bos girilimez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj bos olamaz");
            RuleFor(x => x.MessageContent).MinimumLength(10).WithMessage("Mesaj en az 10 karakter olmalı");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu  en az 3 karakter olmalı");
            RuleFor(x => x.ReciverMail).EmailAddress().WithMessage("Lütfen bir mail adresi giriniz");
        }

    }
}
