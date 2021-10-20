using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
  public  class ChildrenValidator : AbstractValidator<Children>
    {
        public ChildrenValidator()
        {
            RuleFor(c => c.NationalId).NotNull().WithMessage("Hata");
            //RuleFor(c => c.NationalId).MinimumLength(11).WithMessage("TC-Kimlik No 11 Karakterli olmalıdır");
          
        }
    }
}
