using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
   public class UserOperationClaimManager:IUserOperationClaimService
   {
       private IUserOperationClaimDal _userOperationClaimDal;

       public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
       {
           _userOperationClaimDal = userOperationClaimDal;
       }

       public async Task<IDataResult<List<UserOperationClaim>>> GetAllAsync()
       {
           return new SuccessDataResult<List<UserOperationClaim>>(await _userOperationClaimDal.GetAllAsync());
       }

        public async Task<IResult> AddAsync(UserOperationClaim userOperationClaim)
        {
            await _userOperationClaimDal.AddAsync(userOperationClaim);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(UserOperationClaim userOperationClaim)
        {
            await _userOperationClaimDal.UpdateAsync(userOperationClaim);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(UserOperationClaim userOperationClaim)
        {
            await _userOperationClaimDal.DeleteAsync(userOperationClaim);
            return new SuccessResult();
        }
    }
}
