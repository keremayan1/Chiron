using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
   public class EfQuestionDal:EfEntityRepository<Question,SqlContext>,IQuestionDal
   {
       private SqlContext context = new SqlContext();
        public async Task<List<QuestionDetailDto>> GetQuestionDetail(Expression<Func<QuestionDetailDto, bool>> filter = null)
        {
            var result = from question in context.Questions
                join questionTitle in context.QuestionTitles on question.QuestionTitleId equals questionTitle.Id
                where question.QuestionTitleId == questionTitle.Id
                select new QuestionDetailDto
                {
                    QuestionTitleId = questionTitle.Id,
                    QuestionTitleName = questionTitle.QuestionTitleName,
                    QuestionName = question.QuestionName
                };
            return filter == null ?
                await result.ToListAsync() :
                await result.Where(filter).ToListAsync();

        }
    }
}
