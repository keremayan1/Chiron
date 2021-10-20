using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.Concrete.Dto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class ChildrenPersonDetailValidator:AbstractValidator<ChildrenPersonDetail>
    {
        public ChildrenPersonDetailValidator()
        {
            
          //  RuleFor(ps => ps.NationalId).NotEmpty().WithMessage("TC-Kimlik No Boş Olamaz!");
            //RuleFor(ps => ps.NationalId).MinimumLength(11).WithMessage("TC-Kimlik No Minimum 11 Karakter Olmalıdır");
            //RuleFor(ps => ps.NationalId).Length(11).WithMessage("TC-Kimlik No 11 Karakter Olmalıdır");
            RuleFor(ps => ps.ChildrenPerson.FirstName).NotEmpty().WithMessage("Ad Boş Olamaz!");
            RuleFor(c => c.ChildrenPerson.LastName).NotEmpty().WithMessage("Soyad Boş Olamaz!");
            RuleFor(c => c.ChildrenPerson.LastName).MinimumLength(2).WithMessage("Soyad Minimum 2 Karakterli Olmalıdır!");
            RuleForEach(p => p.Telephones).SetValidator(new TelephoneValidator());
            RuleForEach(cp => cp.Addresses).SetValidator(new AddressValidator());
        }
    }
}
