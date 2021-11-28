using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Dto
{
  public  class ChildrenPersonDetail:IDto
    {
       
        public ChildrenPerson ChildrenPerson { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Telephone> Telephones { get; set; }
        




    }
}
