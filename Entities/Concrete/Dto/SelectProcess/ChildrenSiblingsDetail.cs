using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Dto.SelectProcess
{
  public  class ChildrenSiblingsDetail:IDto
    {
        public int Id { get; set; }
        public int ChildrenId { get; set; }
        public int PersonGenderId { get; set; }
        public int EducationStatusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SchoolName { get; set; }
        public string ClassName { get; set; }
        public string PersonName { get; set; }
        public string GenderName { get; set; }

        public string EducationStatusName { get; set; }
        public string WhichChild { get; set; }
        public string TelephoneNumber { get; set; }
        public string ReasonOfApplication { get; set; }
        public bool DoesHaveChildren { get; set; }

    }
}
