using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {

        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Kategori adi bos girilimez");
            RuleFor(x => x.WriterLastName).NotEmpty().WithMessage("Kategori adi bos girilimez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Aciklama bos olamaz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalı");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Kategori adı en fazla 20 karakter olmalı");
            RuleFor(x => x.WriterLastName).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalı");
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");

        }

    }
}
