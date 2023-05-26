using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class QuestionTitle:IEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string QuestionTitleName { get; set; }

    }
}
