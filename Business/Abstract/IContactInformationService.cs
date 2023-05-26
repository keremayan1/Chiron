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
   public interface IContactInformationService:IContactInformationRuleService<ContactInformation>
    {
        Task<IDataResult<List<ContactInformation>>> GetAll();
        Task<IDataResult<ContactInformation>> GetById(int contactInformationId);
        Task<IResult> Add(ContactInformation contactInformation);
        Task<IResult> Update(ContactInformation contactInformation);
        Task<IResult> Delete(ContactInformation contactInformation);

        Task<IResult> MultipleAddWithList(List<ContactInformation> contactInformations);
        Task<IResult> MultipleDeleteWithList(List<ContactInformation> contactInformations);
        Task<IResult> MultipleUpdateWithList(List<ContactInformation> contactInformation);

    }
}
