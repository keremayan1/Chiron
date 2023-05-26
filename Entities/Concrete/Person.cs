using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class Person:IEntity
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }

    }
}
