using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Rules;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
  public  interface ITelephoneService:ITelephoneRuleService
    {
        Task<IDataResult<List<Telephone>>> GetAll();
        Task<IDataResult<Telephone>> GetById(int telephoneId);
        Task<IResult> Add(Telephone telephone);
        Task<IResult> Update(Telephone telephone);
        Task<IResult> Delete(Telephone telephone);
        Task<IDataResult<Telephone>> GetByTelephoneNumber(string telephoneNumber);
        Task<IResult> MultipleAdd(List<Telephone> telephones);


    }
}
