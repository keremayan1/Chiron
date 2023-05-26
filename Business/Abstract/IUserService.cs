using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
   public interface IUserService
    {
        Task<IDataResult<List<User>>> GetAll();
        Task<IResult> Add(User entity);
        Task<IResult> Update(User entity);
        Task<IResult> Delete(User entity);
       List<OperationClaim> GetClaims(User user);
       User  GetByMail(string email);
    }
}
