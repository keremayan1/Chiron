using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Adapters.PersonService
{
  public  interface IKpsService
  {
      Task<bool> Verify(ContactInformation contactInformation);
  }

 
}
