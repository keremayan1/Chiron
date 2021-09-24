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
   public class ChildrenPersonManager:IChildrenPersonService
   {
       private IChildrenPersonDal _childrenPersonDal;

       public ChildrenPersonManager(IChildrenPersonDal childrenPersonDal)
       {
           _childrenPersonDal = childrenPersonDal;
       }


       public async Task<IDataResult<List<ChildrenPerson>>> GetAll()
       {
           return new SuccessDataResult<List<ChildrenPerson>>(await _childrenPersonDal.GetAllAsync());
       }

        public async Task<IDataResult<ChildrenPerson>> GetById(int childrenPersonId)
        {
            return new SuccessDataResult<ChildrenPerson>(
                await _childrenPersonDal.GetAsync(ch => ch.Id == childrenPersonId));
        }

        public async Task<IResult> Add(ChildrenPerson childrenPerson)
        {
            await _childrenPersonDal.AddAsync(childrenPerson);
            return new SuccessResult();
        }

        public async Task<IResult> Update(ChildrenPerson childrenPerson)
        {
            await _childrenPersonDal.UpdateAsync(childrenPerson);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(ChildrenPerson childrenPerson)
        {
            await _childrenPersonDal.DeleteAsync(childrenPerson);
            return new SuccessResult();
        }
    }
}
