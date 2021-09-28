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
    public class TelephoneManager : ITelephoneService
    {
        private ITelephoneDal _telephoneDal;

        public TelephoneManager(ITelephoneDal telephoneDal)
        {
            _telephoneDal = telephoneDal;
        }

        public async Task<IDataResult<List<Telephone>>> GetAll()
        {
            return new SuccessDataResult<List<Telephone>>(await _telephoneDal.GetAllAsync());
        }

        public async Task<IDataResult<Telephone>> GetById(int telephoneId)
        {
            return new SuccessDataResult<Telephone>(await _telephoneDal.GetAsync(p => p.Id == telephoneId));
        }

        public async Task<IResult> Add(Telephone telephone)
        {
            var result = BusinessRules.Run(CheckTelephoneNumberExists(telephone.TelephoneNumber));
            if (result != null)
            {
                return result;
            }
            await _telephoneDal.AddAsync(telephone);
            return new SuccessResult();
        }

        public async Task<IResult> Update(Telephone telephone)
        {
            var result = BusinessRules.Run(CheckTelephoneNumberExists(telephone.TelephoneNumber));
            if (result != null)
            {
                return result;
            }
            await _telephoneDal.UpdateAsync(telephone);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Telephone telephone)
        {
            await _telephoneDal.DeleteAsync(telephone);
            return new SuccessResult();
        }

        public async Task<IDataResult<Telephone>> GetByTelephoneNumber(long telephoneNumber)
        {
            var result = BusinessRules.Run(CheckTelephoneNumberExists(telephoneNumber));
            if (result != null)
            {
                return new ErrorDataResult<Telephone>(result.Message);
            }
            return new SuccessDataResult<Telephone>(
                await _telephoneDal.GetAsync(p => p.TelephoneNumber == telephoneNumber));
        }

       

        public IDataResult<Telephone> GetByTelephoneNumber2(long telephoneNumber)
        {
            return new SuccessDataResult<Telephone>(_telephoneDal.GetAsync(p => p.TelephoneNumber == telephoneNumber)
                .Result);
        }

        public IResult CheckTelephoneNumberExists(long telephoneNumber)
        {
            var result = _telephoneDal.Any(t => t.TelephoneNumber == telephoneNumber);
            if (result)
            {
                return new ErrorResult("jkasdhgaslkdg");
            }

            return new SuccessResult();
        }

    }
}
