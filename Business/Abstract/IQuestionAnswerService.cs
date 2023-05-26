using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public  interface IQuestionAnswerService
    {
        Task<IDataResult<List<QuestionAnswer>>> GetAll();
        Task<IDataResult<QuestionAnswer>> GetByQuestionAnswerId(int questionAnswerId);
        Task<IDataResult<List<QuestionAnswer>>> GetByQuestionId(int questionId);
        Task<IResult> Add(QuestionAnswer questionAnswer);
        Task<IResult> Update(QuestionAnswer questionAnswer);
        Task<IResult> Delete(QuestionAnswer questionAnswer);
        Task<IResult> MultipleAdd(QuestionAnswer[] questionAnswers);

    }
}
