using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.NameSurname).NotEmpty().WithMessage("Lütfen öğrencinin adını ve soyadını giriniz.");
            RuleFor(s => s.NameSurname).MaximumLength(50).WithMessage("Lütfen ad soyad girerken 50 karakteri aşmayınız.");
            RuleFor(s => s.Email).MaximumLength(75).WithMessage("Lütfen mail bilgisi girerken 75 karakteri aşmayınız.");
            RuleFor(s => s.Email).NotEmpty().WithMessage("Lütfen öğrencinin mail adresini giriniz.");
            RuleFor(s => s.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(s => s.PhoneNumber).Length(10).WithMessage("Lütfen geçerli bir telefon numarası giriniz.");
        }
    }
}
