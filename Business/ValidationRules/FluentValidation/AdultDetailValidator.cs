using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.Dto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AdultDetailValidator : AbstractValidator<AdultDetailDto>
    {
        public AdultDetailValidator()
        {
            RuleFor(ad => ad.Adults).SetValidator(new AdultValidator());
            RuleForEach(ad => ad.Addresses).SetValidator(new AddressValidator());
            RuleForEach(ad => ad.Telephones).SetValidator(new TelephoneValidator());
            When(ad => ad.DoesHaveWife == false, () =>
            {
                RuleFor(ad => ad.AdultWifes).SetValidator(new AdultWifeValidator());
            });
            When(ad => ad.DoesHaveChildren == false, () =>
                  {
                      RuleForEach(ad => ad.AdultChildrenDetail).SetValidator(new AdultChildrenDetailValidator());
                  });


        }
    }
}
