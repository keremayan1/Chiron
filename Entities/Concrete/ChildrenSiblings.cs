using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class ChildrenSiblings:PersonInformation,IEntity
    {
        public int ChildrenId { get; set; }
        public string WhichChild { get; set; }
        public int EducationStatusId { get; set; }
    }
}
