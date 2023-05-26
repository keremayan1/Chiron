using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class ContactInformationValidator:AbstractValidator<ContactInformation>
    {
        public ContactInformationValidator()
        {
            RuleFor(a => a.NationalId).NotNull().WithMessage("TC-Kimlik No Boş Geçilemez!");
            RuleFor(a => a.NationalId).MinimumLength(11).WithMessage("TC-Kimlik No 11 Karakter Olmak Zorundadır");
            Include(new PersonInformationValidator());
        }
    }
}
