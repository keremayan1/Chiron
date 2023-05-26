using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IQuestionAnswerDal:IEntityRepository<QuestionAnswer>,IAsyncEntityRepository<QuestionAnswer>
    {
        Task<List<QuestionDetailDto>> GetQuestionDetail(Expression<Func<QuestionDetailDto, bool>> filter = null);
    }
}
