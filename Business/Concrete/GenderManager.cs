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

namespace Business.Concrete
{
    public class GenderManager : IGenderService
    {
        private IGenderDal _genderDal;

        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;
        }

        public async Task<IDataResult<List<Gender>>> GetAll()
        {
            return new SuccessDataResult<List<Gender>>(await _genderDal.GetAllAsync());
        }

        public async Task<IDataResult<Gender>> GetById(int genderId)
        {
            return new SuccessDataResult<Gender>(await _genderDal.GetAsync(g => g.GenderId == genderId));
        }

        public async Task<IResult> Add(Gender gender)
        {
            var result = BusinessRules.Run(CheckIfGenderNameExists(gender.GenderName));
            if (result != null)
            {
                return result;
            }
            await _genderDal.AddAsync(gender);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Gender gender)
        {
            await _genderDal.DeleteAsync(gender);
            return new SuccessResult();
        }

        public async Task<IResult> Update(Gender gender)
        {
            var result = BusinessRules.Run(CheckIfGenderNameExists(gender.GenderName));
            if (result != null)
            {
                return result;
            }
            await _genderDal.UpdateAsync(gender);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Gender>>> GetByName(string genderName)
        {
            return new SuccessDataResult<List<Gender>>(
                await _genderDal.GetAllAsync(g => g.GenderName.ToLower() == genderName.ToLower()));
        }

        public IResult CheckIfGenderNameExists(string genderName)
        {
            var result = _genderDal.Any(g => g.GenderName.ToLower() == genderName.ToLower());
            if (!result)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

    }
}
