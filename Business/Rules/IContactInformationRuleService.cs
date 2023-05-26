using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Rules
{
  public  interface IContactInformationRuleService<T>
    {
        IResult CheckIfNationalIdExists(string nationalId);
        IResult VerifyNationalId(T personInformation);
    }
}
