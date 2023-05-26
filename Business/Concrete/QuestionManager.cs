using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Business;
using Entities.Concrete.Dto;

namespace Business.Concrete
{
   public class QuestionManager:IQuestionService
    {
       private IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public async Task<IDataResult<List<Question>>> GetAll()
        {
            return new SuccessDataResult<List<Question>>(await _questionDal.GetAllAsync());
        }

        public async Task<IDataResult<Question>> GetById(int questionId)
        {
            return new SuccessDataResult<Question>(await _questionDal.GetAsync(q => q.Id == questionId));
        }

        public async Task<IDataResult<List<Question>>> GetByQuestionTitleId(int questionTitleId)
        {
            return new SuccessDataResult<List<Question>>(
                await _questionDal.GetAllAsync(q => q.QuestionTitleId == questionTitleId));
        }

        public async Task<IResult> Add(Question question)
        {
            var result = BusinessRules.Run(QuestionNameToUpper(question));
            if (result!=null)
            {
                return result;
            }
            await _questionDal.AddAsync(question);
            return new SuccessResult();
        }

        public async Task<IResult> Update(Question question)
        {
            await _questionDal.UpdateAsync(question);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Question question)
        {
            await _questionDal.DeleteAsync(question);
            return new SuccessResult();
        }

        public IResult CheckIfQuestionId(int questionId)
        {
            var result = _questionDal.Any(q => q.Id == questionId);
            if (!result)
            {
                return new ErrorResult("Boyle Bir Soru Yoktur");
            }

            return new SuccessResult();
        }

        public async Task<IDataResult<List<QuestionDetailDto>>> GetQuestionDetail()
        {
            return new SuccessDataResult<List<QuestionDetailDto>>(await _questionDal.GetQuestionDetail());
        }

        public async Task<IDataResult<List<QuestionDetailDto>>> GetQuestionDetailByQuestionId(int questionId)
        {
            return new SuccessDataResult<List<QuestionDetailDto>>(
                await _questionDal.GetQuestionDetail(q => q.QuestionId == questionId));
        }

        public async Task<IDataResult<List<QuestionDetailDto>>> GetQuestionDetailByQuestionTitleId(int questionTitleId)
        {
            return new SuccessDataResult<List<QuestionDetailDto>>(
                await _questionDal.GetQuestionDetail(q => q.QuestionTitleId == questionTitleId));
        }

        public IResult QuestionNameToUpper(Question question)
        {
            question.QuestionName = question.QuestionName.ToUpper();
            return new SuccessResult();
        }
    }
}
