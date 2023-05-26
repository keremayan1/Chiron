using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AdultValidator : AbstractValidator<Adult>
    {
        public AdultValidator()
        {
           
           Include(new ContactInformationValidator());
            RuleFor(a => a.JobName).NotNull().WithMessage("Mesleği Boş Olamaz");
            RuleFor(a => a.JobName).MinimumLength(2).WithMessage("Mesleği En Az 2 karakterli olmalıdır");
            RuleFor(a => a.JobName).MaximumLength(150).WithMessage("Mesleği En Fazla 150 karakterli olmalıdır");
            RuleFor(a => a.EthnicName).NotNull().WithMessage("Etnik Boş Geçilemez!");
            RuleFor(a => a.EthnicName).MinimumLength(2).WithMessage("Etnik en az 2 karakterli olmalıdır");
            RuleFor(a => a.EthnicName).MaximumLength(50).WithMessage("Etnik en fazla 50 karakter olmalıdır");
            RuleFor(a => a.HerHasJob).NotNull().WithMessage("Yaptığı iş boş geçilemez");
            RuleFor(a => a.HerHasJob).MinimumLength(2).WithMessage("Yaptığı İş En Az 2 karakter olmalıdır");
            RuleFor(a => a.HerHasJob).MaximumLength(150).WithMessage("Yaptığı İş En fazla 150 karakter olmalıdır");
            RuleFor(a => a.WhereIsLiveHerHasDoes).NotNull().WithMessage("Kiminle yaşadığı yer boş geçilemez!");
            RuleFor(a => a.WhereIsLiveHerHasDoes).MinimumLength(2).WithMessage("Nerede Yaşadığı En Az 2 karakterli olmalıdır");
            RuleFor(a => a.MarriedStatusId).NotNull().WithMessage("Evlilik Durumu Boş geçilemez!");
            RuleFor(a => a.WhereIsLiveCountry).NotNull().WithMessage("Nerede Yaşadığı Boş Geçilemez!");
            RuleFor(a => a.WhereIsLiveCountry).MinimumLength(2).WithMessage("Nerede yaşadığı en az 2 karakterli olmalıdır");



        }
    }
}
