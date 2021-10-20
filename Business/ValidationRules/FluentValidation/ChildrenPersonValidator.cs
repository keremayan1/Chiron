using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class ChildrenPersonValidator:AbstractValidator<ChildrenPerson>
    {
        public ChildrenPersonValidator()
        {
           // RuleFor(ps => ps.NationalId).NotEmpty().WithMessage("TC-Kimlik No Boş Olamaz!");
            //RuleFor(ps => ps.NationalId).MinimumLength(11).WithMessage("TC-Kimlik No Minimum 11 Karakter Olmalıdır");
            //RuleFor(ps => ps.NationalId).Length(11).WithMessage("TC-Kimlik No 11 Karakter Olmalıdır");
            RuleFor(ps => ps.FirstName).NotEmpty().WithMessage("Ad Boş Olamaz!");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Soyad Boş Olamaz!");
            RuleFor(c => c.LastName).MinimumLength(2).WithMessage("Soyad Minimum 2 Karakterli Olmalıdır!");
        }
    }
}
