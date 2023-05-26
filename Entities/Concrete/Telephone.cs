using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
  public  class Telephone:IEntity
    {
        public int Id { get; set; }
        public int PersonInformationId { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
