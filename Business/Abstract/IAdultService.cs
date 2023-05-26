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
  public  interface IAdultService:IContactInformationRuleService<Adult>,ITelephoneRuleService,ITelephoneRuleServiceList
    {
        
        Task<IDataResult<Adult>> GetById(int adultId);
        Task<IResult> AdultDetailDtoAdd(AdultDetailDto adultDetail);
        Task<IDataResult<List<AdultDetailWithRead>>> GetAdultDetail();
        Task<IResult> Delete(int id);
    }
}
