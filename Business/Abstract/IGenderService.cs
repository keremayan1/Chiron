using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
  public  interface IGenderService
  {
      Task<IDataResult<List<Gender>>> GetAll();
      Task<IDataResult<Gender>> GetById(int genderId);
      Task<IResult> Add(Gender gender);
      Task<IResult> Delete(Gender gender);
      Task<IResult> Update(Gender gender);
      Task<IDataResult<List<Gender>>> GetByName(string genderName);
  }
}
