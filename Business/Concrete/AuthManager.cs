using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete.Dto;

namespace Business.Concrete
{
  public  class AuthManager:IAuthService
  {
      private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimService _userOperationClaimService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService)
      {
          _userService = userService;
          _tokenHelper = tokenHelper;
          _userOperationClaimService = userOperationClaimService;
      }

      public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto)
      {
          byte[] passwordHash, passwordSalt;
          var result = BusinessRules.Run(UserExits(userForRegisterDto.Email));
          if (result!=null)
          {
              return new ErrorDataResult<User>(result.Message);
          }
          HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash,out passwordSalt);
          var user = new User
          {
              Email = userForRegisterDto.Email,
              FirstName = userForRegisterDto.FirstName,
              LastName = userForRegisterDto.LastName,
              PasswordHash = passwordHash,
              PasswordSalt = passwordSalt,
              Status = true
          };
         await _userService.Add(user);
         await UserOperationClaimServiceAddAsync(user);
         return new SuccessDataResult<User>(user);

      }

      private async Task UserOperationClaimServiceAddAsync(User user)
      {
          await _userOperationClaimService.AddAsync(new UserOperationClaim
          {
              UserId = user.Id,
              OperationClaimId = 2
          });
      }

      public  IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck ==null)
            {
                return new ErrorDataResult<User>("Kullanici Bulunamadi");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Sifre Yanlis");
            }

            return new SuccessDataResult<User>(userToCheck);
        }

        public IResult UserExits(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("Sistemde boyle bir kullanici vardir");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateAccessToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }
    }
}
