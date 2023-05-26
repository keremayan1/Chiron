using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
  public  interface IFamilyStatusService
  {
      Task<IDataResult<List<FamilyStatus>>> GetAll();
      Task<IDataResult<FamilyStatus>> GetById(int familyId);
      Task<IResult> Add(FamilyStatus familyStatus);
      Task<IResult> Delete(FamilyStatus familyStatus);
      Task<IResult> Update(FamilyStatus familyStatus);
  }
}
