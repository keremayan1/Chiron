using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Dto;

namespace DataAccess.Abstract
{
  public  interface IChildrenDal:IEntityRepository<Children>,IAsyncEntityRepository<Children>
  {
      Task<List<ChildrenDetail>> GetChildrenDetails(Expression<Func<ChildrenDetail, bool>> filter = null);
  }
}
