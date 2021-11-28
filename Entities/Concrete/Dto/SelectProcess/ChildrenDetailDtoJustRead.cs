using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Dto.SelectProcess
{
  public class ChildrenDetailDtoJustRead:IDto
    {
        public int Id { get; set; }
        public string NationalId { get; set; }
        public int PersonGenderId { get; set; }
        public string PersonName { get; set; }
        public string GenderName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SchoolName { get; set; }
        public string ClassName { get; set; }
        public List<string> TelephoneNumber { get; set; }
        public List<string> ChildPerson { get; set; }
        public List<string> ChildPersonTelephones { get; set; }
        public List<string> ChildPersonAddresses { get; set; }

        public List<string> ChildrenSiblings { get; set; }

    }
}
