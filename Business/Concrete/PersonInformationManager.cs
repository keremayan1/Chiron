using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Adapters.PersonService;
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
        private IKpsService _kpsService;
        private IPersonGenderService _personGenderService;
        private IGenderService _genderService;
        private IPersonService _personService;

        public PersonInformationManager(IPersonInformationDal personInformationDal, IKpsService kpsService, IGenderService genderService, IPersonService personService, IPersonGenderService personGenderService)
        {
            _personInformationDal = personInformationDal;
            _kpsService = kpsService;
            _genderService = genderService;
            _personService = personService;
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

        public async Task<IResult> AddAsync(PersonInformation personInformation)
        {
            var result = BusinessRules.Run(GetByPersonId(personInformation.PersonGenderId));
            if (result != null)
            {
                return result;
            }

            personInformation.PersonGenderId = _personGenderService.GetById(personInformation.PersonGenderId).Id;
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

        public async Task<IDataResult<List<PersonInformationDetail>>> GetPersonInformationDetailAsync()
        {
            return new SuccessDataResult<List<PersonInformationDetail>>(await _personInformationDal
                .GetPersonInformationDetail());
        }

        public IResult VerifyNationalId(PersonInformation personInformation)
        {
            var result = _kpsService.Verify(personInformation).Result;
            if (!result)
            {
                return new ErrorResult("Hatali TC");
            }

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

       

        

       
    }
}
