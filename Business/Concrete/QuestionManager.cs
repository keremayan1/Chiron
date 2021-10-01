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

        public async Task<IResult> Add(Question question)
        {
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

       
    }
}
