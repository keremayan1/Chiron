using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionAnswerManager : IQuestionAnswerService
    {
       private IQuestionAnswerDal _questionAnswerDal;

        public QuestionAnswerManager(IQuestionAnswerDal questionAnswerDal)
        {
            _questionAnswerDal = questionAnswerDal;
        }

        public async Task<IResult> Add(QuestionAnswer questionAnswer)
        {
            await _questionAnswerDal.AddAsync(questionAnswer);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(QuestionAnswer questionAnswer)
        {
            await _questionAnswerDal.DeleteAsync(questionAnswer);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<QuestionAnswer>>> GetAll()
        {
            return new SuccessDataResult<List<QuestionAnswer>>(await _questionAnswerDal.GetAllAsync());
        }

        public async Task<IDataResult<QuestionAnswer>> GetByQuestionAnswerId(int questionAnswerId)
        {
            return new SuccessDataResult<QuestionAnswer>(await _questionAnswerDal.GetAsync(qa => qa.Id == questionAnswerId));
        }

        public async Task<IDataResult<List<QuestionAnswer>>> GetByQuestionId(int questionId)
        {
            return new SuccessDataResult<List<QuestionAnswer>>(await _questionAnswerDal.GetAllAsync(qa => qa.QuestionId == questionId));
        }

        public async Task<IResult> Update(QuestionAnswer questionAnswer)
        {
           await _questionAnswerDal.UpdateAsync(questionAnswer);
            return new SuccessResult();
        }
    }
}
