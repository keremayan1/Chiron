using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class AddressValidator:AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.AddressName).NotEmpty().WithMessage("Adres Boş Olamaz!");
            RuleFor(a => a.AddressName).MinimumLength(5).WithMessage("Adres Minumum 5 Karakter Olmalı!");
        }
    }
}
