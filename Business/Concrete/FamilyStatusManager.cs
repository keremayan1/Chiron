using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class FamilyStatusManager:IFamilyStatusService
   {
       private IFamilyStatusDal _familyStatusDal;

       public FamilyStatusManager(IFamilyStatusDal familyStatusDal)
       {
           _familyStatusDal = familyStatusDal;
       }

       public async Task<IDataResult<List<FamilyStatus>>> GetAll()
       {
           return new SuccessDataResult<List<FamilyStatus>>(await _familyStatusDal.GetAllAsync());
       }

        public async Task<IDataResult<FamilyStatus>> GetById(int familyId)
        {
            return new SuccessDataResult<FamilyStatus>(await _familyStatusDal.GetAsync(fs => fs.Id == familyId));
        }

        public async Task<IResult> Add(FamilyStatus familyStatus)
        {
            var result = BusinessRules.Run(CheckIfFamilyStatusNameExists(familyStatus.Name));
            if (result!=null)
            {
                return result;
            }
            await _familyStatusDal.AddAsync(familyStatus);
            return new SuccessResult("Basarili");
        }

        public async Task<IResult> Delete(FamilyStatus familyStatus)
        {
            var result = BusinessRules.Run(CheckIfFamilyStatusNameExists(familyStatus.Name));
            if (result != null)
            {
                return result;
            }
            await _familyStatusDal.DeleteAsync(familyStatus);
            return new SuccessResult("Basarili");
        }

        public async Task<IResult> Update(FamilyStatus familyStatus)
        {
            await _familyStatusDal.UpdateAsync(familyStatus);
            return new SuccessResult();
        }

        public IResult CheckIfFamilyStatusNameExists(string familyName)
        {
            var result = _familyStatusDal.Any(fs => fs.Name.ToLower().Trim() == familyName.ToLower().Trim());
            if (!result)
            {
                return new ErrorResult("Boyle Bir Aile Statusu Vardir");
            }

            return new SuccessResult();
        }
    }
}
