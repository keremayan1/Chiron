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
  public  interface ITelephoneService:ITelephoneRuleService,ITelephoneRuleServiceList
    {
        Task<IDataResult<List<Telephone>>> GetAll();
        Task<IDataResult<Telephone>> GetById(int telephoneId);
        Task<IDataResult<List<Telephone>>> GetByPersonInformationId(int personInformationId);
        Task<IResult> Add(Telephone telephone);
        Task<IResult> Update(Telephone telephone);
        Task<IResult> Delete(Telephone telephone);
        Task<IDataResult<Telephone>> GetByTelephoneNumber(string telephoneNumber);
       

        Task<IResult> MultipleAddWithList(List<Telephone> telephones);
        Task<IResult> MultipleDeleteWithList(List<Telephone> telephones);
        Task<IResult> MultipleUpdateWithList(List<Telephone> telephones);


    }
}
