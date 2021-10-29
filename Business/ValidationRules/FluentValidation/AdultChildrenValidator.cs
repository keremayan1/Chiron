using Entities.Concrete;
using Entities.Concrete.Dto;
using FluentValidation;
using FluentValidation.Validators;

namespace Business.ValidationRules.FluentValidation
{
    public class AdultChildrenValidator :AbstractValidator<AdultChildren>
    {
        public AdultChildrenValidator()
        {
            RuleFor(ac => ac.FirstName).NotNull();
            RuleFor(ac => ac.HowManyChildrens).NotNull().WithMessage("Kaç Tane Çocuk Değeri  Boş Girilemez");
            RuleFor(ac => ac.HowManyChildrens).GreaterThan(0).WithMessage("Kaç Tane çocuk değeri 0'dan büyük olmalıdır");

        }
    }
}