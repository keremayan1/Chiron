using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dto
{
  public  class QuestionDetailDto:IDto
    {
        public int QuestionTitleId { get; set; }
        public int QuestionId { get; set; }
        public int PersonInformationId { get; set; }
        public int PersonId { get; set; }
        public string QuestionTitleName { get; set; }
        public string QuestionName { get; set; }
        public string QuestionAnswer { get; set; }


    }
}
