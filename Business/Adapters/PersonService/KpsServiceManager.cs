using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Concrete;
using NationalIdValidate;

namespace Business.Adapters.PersonService
{
  public  class KpsServiceManager:IKpsService
    {
        public async Task<bool> Verify(ContactInformation contactInformation)
        {
         return  await VerifyId(contactInformation);
        }

      

        public async Task<bool> VerifyId(ContactInformation contactInformation)
        {
            var kps = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var kpsVerification = await kps.TCKimlikNoDogrulaAsync(Convert.ToInt64(contactInformation.NationalId),
                contactInformation.FirstName.ToUpper(), contactInformation.LastName.ToUpper(),
                contactInformation.DateOfBirth.Year);
            return kpsVerification.Body.TCKimlikNoDogrulaResult;
        }
    }
}
