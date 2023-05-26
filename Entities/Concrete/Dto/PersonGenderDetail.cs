using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Dto
{
 public  class PersonGenderDetail:IDto
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string GenderName { get; set; }

    }
}
