using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
 public   interface IChildrenSiblingsService
    {
        Task<IDataResult<List<ChildrenSiblings>>> GetAll();
        Task<IDataResult<ChildrenSiblings>> GetById(int childrenSiblingsId);
        Task<IResult> Add(ChildrenSiblings childrenSiblings);
        Task<IResult> Update(ChildrenSiblings childrenSiblings);
        Task<IResult> Delete(ChildrenSiblings childrenSiblings);

        Task<IResult> MultipleAddWithList(List<ChildrenSiblings> childrenSiblings);
        Task<IResult> MultipleDeleteWithList(List<ChildrenSiblings> childrenSiblings);
        Task<IResult> MultipleUpdateWithList(List<ChildrenSiblings> childrenSiblings);
    }
}
