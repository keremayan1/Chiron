using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class PersonInformationValidator:AbstractValidator<PersonInformation>
    {
        public PersonInformationValidator()
        {
          
            RuleFor(ps => ps.FirstName).NotEmpty().WithMessage("Ad Boş Olamaz!");
            RuleFor(ps => ps.FirstName).MinimumLength(2).WithMessage("Karakter Min 2 Karakter Olmalidir");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Soyad Boş Olamaz!");
            RuleFor(c => c.LastName).MinimumLength(2).WithMessage("Soyad Minimum 2 Karakterli Olmalıdır!");
            RuleFor(ps => ps.DateOfBirth).NotNull().WithMessage("DOB bos gecilemez");
           
        }
    }
}
