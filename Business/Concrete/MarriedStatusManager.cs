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
   public class MarriedStatusManager:IMarriedStatusService
   {
       private IMarriedStatusDal _marriedStatusDal;

       public MarriedStatusManager(IMarriedStatusDal marriedStatusDal)
       {
           _marriedStatusDal = marriedStatusDal;
       }

       public async Task<IDataResult<List<MarriedStatus>>> GetAll()
       {
           return new SuccessDataResult<List<MarriedStatus>>(await _marriedStatusDal.GetAllAsync());
       }

        public async Task<IDataResult<MarriedStatus>> GetById(int marriedStatusId)
        {
            return new SuccessDataResult<MarriedStatus>(
                await _marriedStatusDal.GetAsync(ms => ms.Id == marriedStatusId));
        }

        public async Task<IResult> Add(MarriedStatus marriedStatus)
        {
            var result = BusinessRules.Run(CheckIfMarriedStatusNameExists(marriedStatus.Name),MarriedStatusNameToUpper(marriedStatus));
            if (result!=null)
            {
                return result;
            }
            await _marriedStatusDal.AddAsync(marriedStatus);
            return new SuccessResult();

        }

        public async Task<IResult> Update(MarriedStatus marriedStatus)
        {
            await _marriedStatusDal.UpdateAsync(marriedStatus);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(MarriedStatus marriedStatus)
        {
            await _marriedStatusDal.DeleteAsync(marriedStatus);
            return new SuccessResult();
        }

        public IResult CheckIfMarriedStatusNameExists(string marriedStatusName)
        {
            var result = _marriedStatusDal.Any(ms => ms.Name.ToLower() == marriedStatusName.ToLower());
            if (result)
            {
                return new ErrorResult("Sistemde Boyle Bir Medeni Durum Vardir");
            }

            return new SuccessResult();
        }

        public IResult MarriedStatusNameToUpper(MarriedStatus marriedStatus)
        {
            marriedStatus.Name = marriedStatus.Name.ToUpper();
            return new SuccessResult();
        }
    }
}
