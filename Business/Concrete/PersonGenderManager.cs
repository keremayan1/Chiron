                                                                                                                                                                               using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;

namespace Business.Concrete
{
    public class PersonGenderManager : IPersonGenderService
    {
        private IPersonGenderDal _personGenderDal;
        private IPersonService _personService;
        private IGenderService _genderService;
        

        public PersonGenderManager(IPersonGenderDal personGenderDal, IPersonService personService, IGenderService genderService)
        {
            _personGenderDal = personGenderDal;
            _personService = personService;
            _genderService = genderService;
        }

        public async Task<IDataResult<List<PersonGender>>> GetAll()
        {
            return new SuccessDataResult<List<PersonGender>>(await _personGenderDal.GetAllAsync());
        }

        public async Task<IDataResult<List<PersonGender>>> GetByGenderId(int genderId)
        {
            return new SuccessDataResult<List<PersonGender>>(await _personGenderDal.GetAllAsync(pg => pg.GenderId == genderId));
        }

        public async Task<IDataResult<List<PersonGender>>> GetByPersonId(int personId)
        {
            return new SuccessDataResult<List<PersonGender>>(await _personGenderDal.GetAllAsync(pg => pg.PersonId == personId));
        }

        public async Task<IDataResult<List<PersonGender>>> GetById(int id)
        {
            return new SuccessDataResult<List<PersonGender>>(await _personGenderDal.GetAllAsync(ps => ps.Id == id));
        }

       


        public async Task<IDataResult<List<PersonGender>>> GetByPersonIdAndGenderId(int personId, int genderId)
        {
            return new SuccessDataResult<List<PersonGender>>(
                await _personGenderDal.GetAllAsync(pg => pg.PersonId == personId && pg.GenderId == genderId));
        }

        public async Task<IResult> Add(PersonGender personGender)
        {
            var result = BusinessRules.Run(CheckPersonIdAndGenderId(personGender.PersonId, personGender.GenderId),CheckIfGenderId(personGender.GenderId),CheckIfPersonIdExists(personGender.PersonId));
            if (result != null)
            {
                return result;
            }
            await _personGenderDal.AddAsync(personGender);
            return new SuccessResult("Basarili");
        }

        public async Task<IResult> Delete(PersonGender personGender)
        {
            await _personGenderDal.DeleteAsync(personGender);
            return new SuccessResult();
        }

        public async Task<IResult> Update(PersonGender personGender)
        {
            await _personGenderDal.UpdateAsync(personGender);
            return new SuccessResult();
        }

        public IDataResult<List<PersonGenderDetail>> GetByPersonGenderDetails()
        {
            return new SuccessDataResult<List<PersonGenderDetail>>(_personGenderDal.GetPersonInformationDetail().Result);
        }

        public IResult CheckPersonIdAndGenderId(int personId, int genderId)
        {
            var result = _personGenderDal.AnyAsync(pg => pg.PersonId == personId && pg.GenderId == genderId).Result;
            if (result)
            {
                return new ErrorResult("Sistemde Boyle bir cinsiyet kisi vardir");
            }

            return new SuccessResult();
        }
        public IResult CheckIfPersonIdExists(int personId)
        {
            var result = _personService.GetById(personId).Result;
            if (result != null)
            {
                return new ErrorResult("Boyle bir person yoktur");
            }

            return new SuccessResult();
        }

        public IResult CheckIfGenderId(int genderId)
        {
            var result = _genderService.GetById(genderId);
            if (result != null)
            {
                return new ErrorResult("Boyle bir cinsiyet yoktur");
            }

            return new SuccessResult();
        }

    }
}
