using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IQuestionService
    {
        Task<IDataResult<List<Question>>> GetAll();
        Task<IDataResult<Question>>GetById(int questionId);
        Task<IResult> Add(Question question);
        Task<IResult> Update(Question question);
        Task<IResult> Delete(Question question);
        //Business Code
        IResult CheckIfQuestionId(int questionId);

    }
}
