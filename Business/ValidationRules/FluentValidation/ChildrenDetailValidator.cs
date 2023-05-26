using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.Dto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
  public  class ChildrenDetailValidator:AbstractValidator<ChildrenDetail>
    {
        public ChildrenDetailValidator()
        {
            
            RuleFor(p => p.Children).SetValidator(new ChildrenValidator());
            RuleForEach(p => p.ChildrenPersonDetail).SetValidator(new ChildrenPersonDetailValidator());
            RuleForEach(p => p.Telephones).SetValidator(new TelephoneValidator());
            
        }

        //p=error CS0103: The name 'p' does not exist in the current context
    }
}
