using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class AdultAdultChildren:IEntity
    {
        public int Id { get; set; }
        public int AdultId { get; set; }
        public int AdultChildrenId { get; set; }
    }
}
