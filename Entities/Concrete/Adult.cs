using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using Core.Entities;

namespace Entities.Concrete
{
   public class Adult:ContactInformation,IEntity
    {

        public string EthnicName { get; set; }
        public int ReligionId { get; set; }
        public int EducationStatusId { get; set; }
        public int MarriedStatusId { get; set; }
        public string JobName { get; set; }
        public string HerHasJob { get; set; }
        public string WhereIsLiveCountry { get; set; }
        public string WhereIsLiveHerHasDoes { get; set; }
        public string WhoDidSheHeComeWith { get; set; }
        public string ReasonOfApplication { get; set; }
      
        




      

    }
}
