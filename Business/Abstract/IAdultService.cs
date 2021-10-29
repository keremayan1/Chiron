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
  public  interface IAdultService:IContactInformationRuleService<Adult>,ITelephoneRuleService,ITelephoneRuleServiceList
    {
        Task<IDataResult<List<Adult>>> GetAll();
        Task<IDataResult<Adult>> GetById(int adultId);
        Task<IResult> Add(Adult adult);

        Task<IResult> Update(Adult adult);
        Task<IResult> Delete(Adult adult);
        Task<IDataResult<List<AdultDetailDto>>> GetAdultDetails();
      
        Task<IResult> AdultDetailDtoAdd(AdultDetailDto adultDetail);
    }
}
