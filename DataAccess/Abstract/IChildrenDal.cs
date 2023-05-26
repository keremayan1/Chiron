using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Dto;
using Entities.Concrete.Dto.SelectProcess;

namespace DataAccess.Abstract
{
  public  interface IChildrenDal:IEntityRepository<Children>,IAsyncEntityRepository<Children>
  {
      Task<List<ChildrenDetailDtoJustRead>> GetChildrenDetails(Expression<Func<ChildrenDetailDtoJustRead, bool>> filter = null);
  }
}
