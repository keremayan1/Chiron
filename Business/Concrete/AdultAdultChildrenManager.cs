using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
  public  class AdultAdultChildrenManager:IAdultAdultChildrenService
  {
      private IAdultAdultChildrenDal _adultAdultChildrenDal;

      public AdultAdultChildrenManager(IAdultAdultChildrenDal adultAdultChildrenDal)
      {
          _adultAdultChildrenDal = adultAdultChildrenDal;
      }

      public async Task<IDataResult<List<AdultAdultChildren>>> GetAll()
      {
          return new SuccessDataResult<List<AdultAdultChildren>>(await _adultAdultChildrenDal.GetAllAsync());
      }

        public async Task<IDataResult<AdultAdultChildren>> GetById(int adultAdultChildrenId)
        {
            return new SuccessDataResult<AdultAdultChildren>(
                await _adultAdultChildrenDal.GetAsync(aac => aac.Id == adultAdultChildrenId));
        }

        public async Task<IDataResult<List<AdultAdultChildren>>> GetByAdultId(int adultId)
        {
            return new SuccessDataResult<List<AdultAdultChildren>>(
                await _adultAdultChildrenDal.GetAllAsync(aac => aac.AdultId == adultId));
        }

        public async Task<IDataResult<List<AdultAdultChildren>>> GetByAdultChildrenId(int adultChildrenId)
        {
            return new SuccessDataResult<List<AdultAdultChildren>>(
                await _adultAdultChildrenDal.GetAllAsync(aac => aac.AdultChildrenId == adultChildrenId));
        }


        public async Task<IResult> Add(AdultAdultChildren adultAdultChildren)
        {
            await _adultAdultChildrenDal.AddAsync(adultAdultChildren);
            return new SuccessResult();
        }

        public async Task<IResult> Update(AdultAdultChildren adultAdultChildren)
        {
            await _adultAdultChildrenDal.UpdateAsync(adultAdultChildren);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(AdultAdultChildren adultAdultChildren)
        {
            await _adultAdultChildrenDal.DeleteAsync(adultAdultChildren);
            return new SuccessResult();
        }

        public async Task<IResult> MultipleAddWithList(List<AdultAdultChildren> adultAdultChildrens)
        {
            await _adultAdultChildrenDal.MultipleAddAsyncWithList(adultAdultChildrens);
            return new SuccessResult();
        }
  }
}
