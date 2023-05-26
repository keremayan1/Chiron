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

namespace Business.Concrete
{
    public class QuestionAnswerManager : IQuestionAnswerService
    {
       private IQuestionAnswerDal _questionAnswerDal;
       private IQuestionService _questionService;

        public QuestionAnswerManager(IQuestionAnswerDal questionAnswerDal, IQuestionService questionService)
        {
            _questionAnswerDal = questionAnswerDal;
            _questionService = questionService;
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

        public async Task<IResult> MultipleAdd(QuestionAnswer[] questionAnswers)
        {
            foreach (var questionAnswer in questionAnswers)
            {
                var businessRules = BusinessRules.Run(CheckIfQuestionId(questionAnswer.QuestionId));
                if (businessRules != null)
                {
                    return businessRules;
                }

                await _questionAnswerDal.AddAsync(questionAnswer);
            }
          
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

        public IResult CheckIfQuestionId(int questionId)
        {
            var result = _questionService.CheckIfQuestionId(questionId);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            return new SuccessResult();
        }

     
    }
}
