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
        public ContactValidator() {

            RuleFor(x => x.UserMail).NotEmpty().WithMessage("E-Posta Adresini Boş Geçemezsiniz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Boş Geçemezsiniz!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En Az 3 karakter yazabilirsiniz!");
            RuleFor(x => x.Message).MinimumLength(20).WithMessage("En Az 20 karakter yazabilirsiniz!");
            RuleFor(x => x.Message).MaximumLength(50).WithMessage("En Fazla 50 karakter yazabilirsiniz!");
        }
    }
}
