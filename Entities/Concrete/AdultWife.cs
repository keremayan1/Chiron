using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class AdultWife:PersonInformation,IEntity
    {
        public int WifeId { get; set; }
        public string JobName { get; set; }

    }
}
