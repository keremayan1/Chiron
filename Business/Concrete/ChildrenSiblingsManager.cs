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
   public class ChildrenSiblingsManager:IChildrenSiblingsService
   {
       private IChildrenSiblingsDal _childrenSiblingsDal;

       public ChildrenSiblingsManager(IChildrenSiblingsDal childrenSiblingsDal)
       {
           _childrenSiblingsDal = childrenSiblingsDal;
       }

       public async Task<IDataResult<List<ChildrenSiblings>>> GetAll()
       {
           return new SuccessDataResult<List<ChildrenSiblings>>(await _childrenSiblingsDal.GetAllAsync());
       }

        public async Task<IDataResult<ChildrenSiblings>> GetById(int childrenSiblingsId)
        {
            return new SuccessDataResult<ChildrenSiblings>(
                await _childrenSiblingsDal.GetAsync(cs => cs.Id == childrenSiblingsId));
        }

        public async Task<IResult> Add(ChildrenSiblings childrenSiblings)
        {
            await _childrenSiblingsDal.AddAsync(childrenSiblings);
            return new SuccessResult();
        }

        public async Task<IResult> Update(ChildrenSiblings childrenSiblings)
        {
            await _childrenSiblingsDal.UpdateAsync(childrenSiblings);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(ChildrenSiblings childrenSiblings)
        {
            await _childrenSiblingsDal.DeleteAsync(childrenSiblings);
            return new SuccessResult();
        }

        public async Task<IResult> MultipleAddWithList(List<ChildrenSiblings> childrenSiblings)
        {
            await _childrenSiblingsDal.MultipleAddAsyncWithList(childrenSiblings);
            return new SuccessResult();
        }

        public async Task<IResult> MultipleDeleteWithList(List<ChildrenSiblings> childrenSiblings)
        {
            await _childrenSiblingsDal.MultipleDeleteAsyncWithList(childrenSiblings);
            return new SuccessResult();
        }

        public async Task<IResult> MultipleUpdateWithList(List<ChildrenSiblings> childrenSiblings)
        {
            await _childrenSiblingsDal.MultipleUpdateAsyncWithList(childrenSiblings);
            return new SuccessResult();
        }
    }
}
