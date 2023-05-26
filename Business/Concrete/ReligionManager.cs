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
   public class ReligionManager:IReligionService
   {
       private IReligionDal _religionDal;

       public ReligionManager(IReligionDal religionDal)
       {
           _religionDal = religionDal;
       }

       public async Task<IDataResult<List<Religion>>> GetAll()
       {
           return new SuccessDataResult<List<Religion>>(await _religionDal.GetAllAsync());
       }

        public async Task<IDataResult<Religion>> GetById(int religionId)
        {
            return new SuccessDataResult<Religion>(await _religionDal.GetAsync(r => r.Id == religionId));
        }

        public async Task<IResult> Add(Religion religion)
        {
            await _religionDal.AddAsync(religion);
            return new SuccessResult();
        }

        public async Task<IResult> Update(Religion religion)
        {
            await _religionDal.UpdateAsync(religion);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Religion religion)
        {
            await _religionDal.DeleteAsync(religion);
            return new SuccessResult();
        }

        public async Task<IResult> MultipleAdd2(List<Religion> religions)
        {
            await _religionDal.MultipleAddAsyncWithList(religions);
            return new SuccessResult();
        }
    }
}
