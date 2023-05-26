using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Results;

namespace Entities.Concrete
{
   public class FamilyStatus:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
