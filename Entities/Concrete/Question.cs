using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public  class Question:IEntity
    {
        public int Id { get; set; }
        public int QuestionTitleId { get; set; }
        public string QuestionName { get; set; }

    }
}
