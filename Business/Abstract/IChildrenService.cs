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
       Task<IDataResult<Children>> GetById(int childrenId);
       Task<IResult> Add(ChildrenDetail childrenDetail);
       Task<IResult> Update(ChildrenDetail childrenDetail);
       Task<IResult> Delete(ChildrenDetail childrenDetail);

       Task<IDataResult<List<ChildrenDetail>>> GetChildrenDetails();

   }
}
