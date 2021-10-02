using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Rules;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dto;

namespace Business.Abstract
{
   public interface IChildrenPersonService:IPersonInformationRuleService<ChildrenPerson>,ITelephoneRuleService
    {
        Task<IDataResult<List<ChildrenPerson>>> GetAll();
        Task<IDataResult<ChildrenPerson>> GetById(int childrenPersonId);
     
        Task<IResult> Update(ChildrenPerson childrenPerson);
        Task<IResult> Delete(ChildrenPerson childrenPerson);


        Task<IResult> AddAsync(ChildrenPersonDetail childrenPersonDetail);
        Task<IDataResult<List<ChildrenPersonDetail>>> GetChildrenPersonDetails();
        Task<IResult> MultipleAdd2(ChildrenPersonDetail[] childrenPersonDetails);




    }
}
