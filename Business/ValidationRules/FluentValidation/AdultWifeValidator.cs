using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class AdultWifeValidator:AbstractValidator<AdultWife>
    {
        public AdultWifeValidator()
        {
            Include(new PersonInformationValidator());
            RuleFor(a => a.JobName).NotNull().WithMessage("Mesleği Boş Olamaz");
            RuleFor(a => a.JobName).MinimumLength(2).WithMessage("Mesleği En Az 2 karakterli olmalıdır");
            RuleFor(a => a.JobName).MaximumLength(150).WithMessage("Mesleği En Fazla 150 karakterli olmalıdır");
        }
    }
}
