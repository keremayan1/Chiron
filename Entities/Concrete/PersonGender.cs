using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class PersonGender:IEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int GenderId{ get; set; }
    }
}
