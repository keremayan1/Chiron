using System;
using Core.Entities;

namespace Entities
{
    public class PersonInformation:IEntity
    {
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}