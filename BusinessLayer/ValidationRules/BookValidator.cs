using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b=>b.BookName).NotEmpty().WithMessage("Lütfen kitap adını giriniz.");
            RuleFor(b => b.BookName).MaximumLength(75).WithMessage("Bu kitap adı çok uzun.");
            RuleFor(b => b.BookAuthor).NotEmpty().WithMessage("Lütfen kitabın yazarını giriniz.");
            RuleFor(b => b.BookAuthor).MaximumLength(75).WithMessage("Yazar ismi çok uzun.");
        }
    }
}
