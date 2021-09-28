using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class TelephoneValidator:AbstractValidator<Telephone> {
       public TelephoneValidator()
       {
           RuleFor(t => t.TelephoneNumber).NotEmpty();
           RuleFor(t => t.TelephoneNumber).MinimumLength(10).WithMessage("10 karakter");
       }
    }
}
