using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Dto
{
  public  class ChildrenPersonDetail:IDto
    {
        //public int Id { get; set; }
        //public int ChildrenId { get; set; }
        //public int PersonInformationId { get; set; }
        //public int PersonGenderId { get; set; }
        //public int FamilyStatusId { get; set; }
        //public int EducationStatusId { get; set; }
        
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public string PersonName { get; set; }
        //public string GenderName { get; set; }
        //public string FamilyName { get; set; }
        //public string EducationStausName { get; set; }
        //public string JobName { get; set; }

        public ChildrenPerson ChildrenPerson { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Telephone> Telephones { get; set; }
        




    }
}
