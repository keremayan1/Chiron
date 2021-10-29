using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.Dto;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
  public  class AdultDetailValidator:AbstractValidator<AdultDetailDto>
    {
        public AdultDetailValidator()
        {
          
            RuleForEach(ad => ad.Addresses).SetValidator(new AddressValidator());
            RuleForEach(ad => ad.Telephones).SetValidator(new TelephoneValidator());
            RuleFor(ad => ad.DoesHaveChildren).NotNull().WithMessage("Bos olamaz");
            RuleFor(ad => ad.DoesHaveWife).NotNull().WithMessage("Evlilik Durumu Bos Gecilemez");
           // RuleForEach(ad => ad.AdultChildrenDetail).SetValidator(new AdultChildrenDetailValidator());
            RuleFor(ad => ad.Adults).SetValidator(new AdultValidator());
            When(ad => ad.DoesHaveChildren==true, () =>
                RuleForEach(ad => ad.AdultChildrenDetail).SetValidator(new AdultChildrenDetailValidator()));


        }
    }
}
