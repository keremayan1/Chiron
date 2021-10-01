using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class QuestionTitleManager: IQuestionTitleService
    {
        private IQuestionTitleDal _questionTitleDal;

        public QuestionTitleManager(IQuestionTitleDal questionTitleDal)
        {
            _questionTitleDal = questionTitleDal;
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Add(QuestionTitle questionTitle)
        {
            await _questionTitleDal.AddAsync(questionTitle);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(QuestionTitle questionTitle)
        {
            await _questionTitleDal.DeleteAsync(questionTitle);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<QuestionTitle>>> GetAll()
        {
            return new SuccessDataResult<List<QuestionTitle>>(await _questionTitleDal.GetAllAsync());
        }

        public async Task<IDataResult<List<QuestionTitle>>> GetByPersonId(int personId)
        {
            return new SuccessDataResult<List<QuestionTitle>>(await _questionTitleDal.GetAllAsync(qt => qt.PersonId == personId));
        }

        public async Task<IDataResult<QuestionTitle>> GetByQuestionTitleId(int questionTitleId)
        {
            return new SuccessDataResult<QuestionTitle>(await _questionTitleDal.GetAsync(qt => qt.Id == questionTitleId));
        }

        public async Task<IResult> Update(QuestionTitle questionTitle)
        {
            await _questionTitleDal.UpdateAsync(questionTitle);
            return new SuccessResult();
        }
    }
}
