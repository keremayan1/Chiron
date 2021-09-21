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
   public interface IPersonGenderDal:IEntityRepository<PersonGender>,IAsyncEntityRepository<PersonGender>
   {
       Task<List<PersonGenderDetail>> GetPersonInformationDetail(
           Expression<Func<PersonGenderDetail, bool>> filter = null);
   }
}
