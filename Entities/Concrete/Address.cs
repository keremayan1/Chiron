using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
  public  class Address:IEntity
    {
        public int AddressId { get; set; }
        public int PersonInformationId { get; set; }
        public string AddressName { get; set; }

    }
}
