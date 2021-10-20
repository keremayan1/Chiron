using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Rules
{
    public interface IContactInformationRuleServiceList<T>
    {
        IResult CheckIfNationalIdExistsList(List<T> nationalId);
        IResult VerifyNationalIdList(List<T> personInformation);
    }
}
