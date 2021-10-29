using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class AdultWifeManager:IAdultWifeService
   {
       private IAdultWifeDal _adultWifeDal;

       public AdultWifeManager(IAdultWifeDal adultWifeDal)
       {
           _adultWifeDal = adultWifeDal;
       }

       public async Task<IDataResult<List<AdultWife>>> GetAll()
       {
           return new SuccessDataResult<List<AdultWife>>(await _adultWifeDal.GetAllAsync());
       }

        public async Task<IDataResult<AdultWife>> GetById(int adultWifeId)
        {
            return new SuccessDataResult<AdultWife>(await _adultWifeDal.GetAsync(aw => aw.Id == adultWifeId));
        }
       
        public async Task<IResult> Add(AdultWife adultWife)
        {
            var result = BusinessRules.Run(ToUpper(adultWife));
            if (result!=null)
            {
                return result;
            }
            await _adultWifeDal.AddAsync(adultWife);
            return new SuccessResult();
        }

        public async Task<IResult> Update(AdultWife adultWife)
        {
            var result = BusinessRules.Run(ToUpper(adultWife));
            if (result != null)
            {
                return result;
            }
            await _adultWifeDal.UpdateAsync(adultWife);
            return new SuccessResult();

        }

        public async Task<IResult> Delete(AdultWife adultWife)
        {
            await _adultWifeDal.DeleteAsync(adultWife);
            return new SuccessResult();
        }

        public IResult ToUpper(AdultWife adultWife)
        {
            adultWife.FirstName = adultWife.FirstName.ToUpper();
            adultWife.LastName = adultWife.LastName.ToUpper();
            adultWife.JobName = adultWife.JobName.ToUpper();
            return new SuccessResult();
        }
    }
}
