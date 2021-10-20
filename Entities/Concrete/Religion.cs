using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class Religion:IEntity
    {
        public int Id { get; set; }
        public string ReligionName { get; set; }
    }
}
