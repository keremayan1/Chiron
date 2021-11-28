using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Dto
{
   public class AdultDetailDto:IDto
    {
        
        public Adult Adults { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Telephone> Telephones { get; set; }
        public string ReasonOfApplication { get; set; }
        public bool DoesHaveChildren { get; set; }
        public List<AdultChildrenDetailDto> AdultChildrenDetail { get; set; }
        public bool DoesHaveWife { get; set; }
        public AdultWife AdultWifes { get; set; }
     




    }
}
