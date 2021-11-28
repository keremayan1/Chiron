using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Rules;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dto;
using Entities.Concrete.Dto.SelectProcess;

namespace Business.Abstract
{
    public interface IChildrenService : ITelephoneRuleService,ITelephoneRuleServiceList,IContactInformationRuleService<Children>
    {
        Task<IDataResult<List<Children>>> GetAll();
        IDataResult<Children> GetById(int childrenId);
        Task<IResult> Add(Children children);
        Task<IResult> Delete(Children children);
        Task<IResult> Update(Children children);
        Task<IResult> MultipleAdd(List<Children> childrens);



        //ChildrenDetail
     
        Task<IResult> MultipleChildrenDetailAdd(ChildrenDetail children);
        Task<IResult> MultipleChildrenDetailUpdate(ChildrenDetail children);
        Task<IResult> MultipleChildrenDetailDelete(ChildrenDetail children);
        //
        Task<IDataResult<List<ChildrenDetailDtoJustRead>>> GetChildrenDetails();

    }
}
