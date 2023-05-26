using Entities.Concrete.Dto;
using FluentValidation;
using FluentValidation.Validators;

namespace Business.ValidationRules.FluentValidation
{
    public class AdultChildrenDetailValidator : AbstractValidator<AdultChildrenDetailDto>
    {
        public AdultChildrenDetailValidator()
        {
       
            RuleForEach(ac => ac.AdultChildren).SetValidator(new AdultChildrenValidator());
            RuleFor(ac => ac.FamilyStatusId).GreaterThanOrEqualTo(0).WithMessage("Aile Durumu Id'si 0'dan buyuk olmalidir");

        }
    }
}