using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    class DraftValidator:AbstractValidator<Draft>
    {
        public DraftValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı kısmı boş geçilemez");
            RuleFor(x => x.DraftSubject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.DraftContent).NotEmpty().WithMessage("Mesaj içeriğini boş geçemezsiniz");
            RuleFor(x => x.DraftSubject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.DraftSubject).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter girişi yapınız");
        }
    }
}
