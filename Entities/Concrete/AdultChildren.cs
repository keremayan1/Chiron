using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class AdultChildren:PersonInformation,IEntity
    {
       
        public int HowManyChildrens { get; set; }

    }
}
