﻿using System;
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
   public class UserManager:IUserService
   {
       private IUserDal _userDal;

       public UserManager(IUserDal userDal)
       {
           _userDal = userDal;
       }

       public async Task<IDataResult<List<User>>> GetAll()
       {
           return new SuccessDataResult<List<User>>(await _userDal.GetAllAsync());
       }

        public async Task<IResult> Add(User entity)
        {
            await _userDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> Update(User entity)
        {
            await _userDal.UpdateAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(User entity)
        {
            await _userDal.DeleteAsync(entity);
            return new SuccessResult();
        }

        public  List<OperationClaim> GetClaims(User user)
        {
            return  _userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
