using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Dto
{
   public class ChildrenDetail:IDto
    {
        //public int Id { get; set; }
        //public int PersonGenderId { get; set; }
        public int PersonInformationId { get; set; }
        public string PersonName { get; set; }
        //public string NationalId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string GenderName { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public string SchoolName { get; set; }
        //public string ClassName { get; set; }
        public Children Children { get; set; }
        public Address Address1 { get; set; }

        public Address[] Address { get; set; }
        public Telephone Telephone { get; set; }
        //public string TelephoneNumber { get; set; }

        public ChildrenPersonDetail PersonDetail { get; set; }
        public ChildrenPersonDetail[] ChildrenPersonDetail { get; set; }
       
        


    }
}
