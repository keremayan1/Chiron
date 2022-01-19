using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class PersonInformation:IEntity
    {
        public int Id { get; set; }
        public int PersonGenderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime IsAdded { get; set; }

        public bool IsActive { get; set; }
    }
}