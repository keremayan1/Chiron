using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete.Dto;

namespace Business.Abstract
{
  public  interface IAuthService
    {
        Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExits(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
