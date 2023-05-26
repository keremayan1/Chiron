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
   public interface IChildrenPersonService:ITelephoneRuleServiceList,ITelephoneRuleService
    {
        Task<IDataResult<List<ChildrenPerson>>> GetAll();
        Task<IDataResult<ChildrenPerson>> GetById(int childrenPersonId);
        Task<IResult> Update(ChildrenPerson childrenPerson);
        Task<IResult> Delete(ChildrenPerson childrenPerson);
       
        Task<IResult> MultipleAddWithList(List<ChildrenPersonDetail> childrenPersonDetails);
        Task<IResult> MultipleDeleteWithList(List<ChildrenPersonDetail> childrenPersonDetails);
        Task<IResult> MultipleUpdateWithList(List<ChildrenPersonDetail> childrenPersonDetails);

        Task<IResult> AddChildrenPersonDetail(ChildrenPersonDetail childrenPersonDetail);
        Task<IResult> Add(ChildrenPerson childrenPerson);
        Task<IResult> AddWithList(List<ChildrenPerson> childrenPersons);




    }
}
