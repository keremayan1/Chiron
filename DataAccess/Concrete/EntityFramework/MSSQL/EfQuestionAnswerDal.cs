using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Entities.Concrete;
using Entities.Concrete.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
    public class EfQuestionAnswerDal : EfEntityRepository<QuestionAnswer, SqlContext>, IQuestionAnswerDal
    {
        SqlContext context = new SqlContext();

        public async Task<List<QuestionDetailDto>> GetQuestionDetail(Expression<Func<QuestionDetailDto, bool>> filter = null)
        {
            var result = from questionTitle in context.QuestionTitles
                         join person in context.Persons on questionTitle.PersonId equals person.PersonId
                         join question in context.Questions on questionTitle.Id equals question.QuestionTitleId
                         join questionAnswer in context.QuestionAnswers on question.Id equals questionAnswer.QuestionId
                         select new QuestionDetailDto
                         {
                             QuestionTitleName = questionTitle.QuestionTitleName,
                             QuestionName = question.QuestionName,
                             QuestionAnswer = questionAnswer.Answer
                         };

            return filter == null ?
                await result.ToListAsync() :
                await result.Where(filter).ToListAsync();
        }
    }
}
