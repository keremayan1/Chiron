using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Dto
{
  public  class AdultChildrenDetailDto:IDto
    {
       
        public List<AdultChildren> AdultChildren { get; set; }
        public int FamilyStatusId { get; set; }
      
    }
}
