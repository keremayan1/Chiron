using Core.Entities;
using System;

namespace Entities.Concrete.Dto.SelectProcess
{
    public class GetAdultChildrenDto:IDto
    {
        public int Id { get; set; }
        public int PersonGenderId { get; set; }
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SchoolName { get; set; }
        public string ClassName { get; set; }
        public string PersonName { get; set; }
        public string GenderName { get; set; }
        public string HowManyChildren { get; set; }
        public string FamilyStatusName { get; set; }



    }
}
