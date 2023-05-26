using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.Dto;

namespace DataAccess.Abstract
{
   public interface IQuestionDal:IEntityRepository<Question>,IAsyncEntityRepository<Question>
   {
       Task<List<QuestionDetailDto>> GetQuestionDetail(Expression<Func<QuestionDetailDto, bool>> filter = null);
   }
}
