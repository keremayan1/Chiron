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
  public  interface IAdultDal:IEntityRepository<Adult>,IAsyncEntityRepository<Adult>
  {
        Task<List<AdultDetailWithRead>> GetAdultsDetail(Expression<Func<AdultDetailWithRead, bool>> filter = null);
    }
}
