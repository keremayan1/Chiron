using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dto;

namespace Business.Abstract
{
   public interface IChildrenService
   {
       Task<IDataResult<List<Children>>> GetAll();
         IDataResult<Children> GetById(int childrenId);
       Task<IResult> Add(Children children);
       Task<IResult> Update(Children children);
       Task<IResult> Delete(Children children);

       IDataResult<List<ChildrenDetail>> GetChildrenDetails();

   }
}
