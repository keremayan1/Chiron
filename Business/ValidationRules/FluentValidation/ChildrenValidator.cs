using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
  public  class ChildrenValidator : AbstractValidator<Children>
    {
        public ChildrenValidator()
        {
            Include(new ContactInformationValidator());
        }
    }
}
