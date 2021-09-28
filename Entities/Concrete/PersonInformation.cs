using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class PersonInformation:IEntity
    {
        public int Id { get; set; }
        public int PersonGenderId { get; set; }
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}