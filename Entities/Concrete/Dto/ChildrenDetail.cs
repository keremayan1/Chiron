using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Dto
{
   public class ChildrenDetail:IDto
    {
      
        public Children Children { get; set; }
        
        public List<Telephone> Telephones { get; set; }

        public List<ChildrenPersonDetail> ChildrenPersonDetail { get; set; }

        public bool DoedHaveChildrenSiblings { get; set; }

        public List<ChildrenSiblings> ChildrenSiblings { get; set; }







    }
}
