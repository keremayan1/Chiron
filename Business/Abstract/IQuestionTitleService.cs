using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IQuestionTitleService
    {
        Task<IDataResult<List<QuestionTitle>>> GetAll();
        Task<IDataResult<QuestionTitle>> GetByQuestionTitleId(int questionTitleId);
        Task<IResult> Add(QuestionTitle questionTitle);
        Task<IResult> Update(QuestionTitle questionTitle);
        Task<IResult> Delete(QuestionTitle questionTitle);
        Task<IDataResult<List<QuestionTitle>>> GetByPersonId(int personId);
    }
}
