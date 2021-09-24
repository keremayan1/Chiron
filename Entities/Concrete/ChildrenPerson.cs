using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class ChildrenPerson:IEntity
    {
        public int Id { get; set; }
        public int ChildrenId { get; set; }
        public int PersonInformationId { get; set; }
        public int PersonGenderId { get; set; }
        public int FamilyStatusId { get; set; }
        public int EducationStatusId { get; set; }
        public int JobsId { get; set; }
    }
}
