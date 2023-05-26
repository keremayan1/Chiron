using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class QuestionAnswer:IEntity
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int PersonInformationId { get; set; }
        public string Answer { get; set; }
    }
}
