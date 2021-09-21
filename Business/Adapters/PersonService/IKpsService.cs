using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Adapters.PersonService
{
  public  interface IKpsService
  {
      Task<bool> Verify(PersonInformation personInformation);
  }

 
}
