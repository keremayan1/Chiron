using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.Dto;

namespace Business.Abstract
{
   public interface IQuestionService
    {
        Task<IDataResult<List<Question>>> GetAll();
        Task<IDataResult<Question>>GetById(int questionId);
        Task<IDataResult<List<Question>>> GetByQuestionTitleId(int questionTitleId);
        Task<IResult> Add(Question question);
        Task<IResult> Update(Question question);
        Task<IResult> Delete(Question question);
        //Business Code
        IResult CheckIfQuestionId(int questionId);

        //QuestionDetailDto

        Task<IDataResult<List<QuestionDetailDto>>> GetQuestionDetail();
        Task<IDataResult<List<QuestionDetailDto>>> GetQuestionDetailByQuestionId(int questionId);
        Task<IDataResult<List<QuestionDetailDto>>> GetQuestionDetailByQuestionTitleId(int questionTitleId);

    }
}
