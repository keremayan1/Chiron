using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Adapters.PersonService;
using Business.Rules;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;

namespace Business.Concrete
{
    public class PersonInformationManager : IPersonInformationService
    {
        private IPersonInformationDal _personInformationDal;
       
        private IPersonGenderService _personGenderService;
        

        public PersonInformationManager(IPersonInformationDal personInformationDal, IPersonGenderService personGenderService)
        {
            _personInformationDal = personInformationDal;
           
            
            _personGenderService = personGenderService;
        }

        public async Task<IDataResult<List<PersonInformation>>> GetAllAsync()
        {
            return new SuccessDataResult<List<PersonInformation>>(await _personInformationDal.GetAllAsync());
        }

        public async Task<IDataResult<PersonInformation>> GetById(int personId)
        {
            return new SuccessDataResult<PersonInformation>(
                await _personInformationDal.GetAsync(p => p.Id == personId));
        }
        [ValidationAspect(typeof(PersonInformationValidator))]
        public async Task<IResult> AddAsync(PersonInformation personInformation)
        {
            var result = BusinessRules.Run(ToUpper(personInformation));

            if (result != null)
            {
                return result;
            }

            
            await _personInformationDal.AddAsync(personInformation);
            return new SuccessResult("Basarili");
        }

        public async Task<IResult> DeleteAsync(PersonInformation personInformation)
        {
            await _personInformationDal.DeleteAsync(personInformation);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(PersonInformation personInformation)
        {
            await _personInformationDal.UpdateAsync(personInformation);
            return new SuccessResult();
        }

       
       

        public IResult GetByPersonId(int id)
        {
            var result = _personGenderService.GetById(id);
            if (result.Result==null)
            {
                return new ErrorResult("Hata");
            }

            return new SuccessResult();
        }

        public IResult ToUpper(PersonInformation personInformation)
        {
            personInformation.FirstName = personInformation.FirstName.ToUpper();
            personInformation.LastName = personInformation.LastName.ToUpper();
            return new SuccessResult();
        }

       

        

       
    }
}
