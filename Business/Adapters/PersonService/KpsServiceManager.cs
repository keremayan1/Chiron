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
        public async Task<bool> Verify(PersonInformation personInformation)
        {
         return  await VerifyId(personInformation);
        }

        public async Task<bool> VerifyId(PersonInformation personInformation)
        {
            var kps = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var kpsVerification = await kps.TCKimlikNoDogrulaAsync(Convert.ToInt64(personInformation.NationalId),
                personInformation.FirstName.ToUpper(), personInformation.LastName.ToUpper(),
                personInformation.DateOfBirth.Year);
            return kpsVerification.Body.TCKimlikNoDogrulaResult;
        }
    }
}
