using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Dto.SelectProcess
{
    public class AdultDetailWithRead : IDto
    {
        public int Id { get; set; }
        public int PersonGenderId { get; set; }
        public string NationalId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        public string PersonName { get; set; }
        public string GenderName { get; set; }
        public string EthnicName { get; set; }
        public int ReligionId { get; set; }
        public string ReligionName { get; set; }
        public int EducationStatusId { get; set; }
        public string EducationStatusName { get; set; }
        public int MarriedStatusId { get; set; }
        public string MarriedStatusName { get; set; }
        public string JobName { get; set; }
        public string HerHasJob { get; set; }
        public string WhereIsLiveCountry { get; set; }
        public string WhereIsLiveHerHasDoes { get; set; }
        public string WhoDidSheHeComeWith { get; set; }
        public string ReasonOfApplication { get; set; }

        public string AdultWife { get; set; }
        public List<string> Addresses { get; set; }
        public List<string> Telephones { get; set; }
        public List<string> AdultChildren { get; set; }


       

    }
}
