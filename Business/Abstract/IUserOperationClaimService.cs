using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
   public interface IUserOperationClaimService
    {
        Task<IDataResult<List<UserOperationClaim>>> GetAllAsync();
        Task<IResult> AddAsync(UserOperationClaim userOperationClaim);
        Task<IResult> UpdateAsync(UserOperationClaim userOperationClaim);
        Task<IResult> DeleteAsync(UserOperationClaim userOperationClaim);
    }
}
