using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class Adult:PersonInformation,IEntity
    {
        public int EducationStatusId { get; set; }
        public int MarriedStatusId { get; set; }
        public int JobId { get; set; }

 

    }
}
