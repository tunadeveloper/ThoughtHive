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
        public MessageValidator() {

            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("boş geçemezsiniz").EmailAddress().WithMessage("Geçerli bir e-posta adresini giriniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("boş geçemezsiniz");
        }
    }
}
