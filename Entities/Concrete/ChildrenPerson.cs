using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class ChildrenPerson:PersonInformation,IEntity
    {
        public int ChildrenId { get; set; }
        public int FamilyStatusId { get; set; }
        public int EducationStatusId { get; set; }
        public string JobName { get; set; }
       
    }
}
