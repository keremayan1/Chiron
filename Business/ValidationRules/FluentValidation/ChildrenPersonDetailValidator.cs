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

            RuleFor(cp => cp.ChildrenPerson).SetValidator(new ChildrenPersonValidator());
            RuleForEach(p => p.Telephones).SetValidator(new TelephoneValidator());
            RuleForEach(cp => cp.Addresses).SetValidator(new AddressValidator());
        }
    }
}
