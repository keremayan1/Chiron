using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
  public  interface IAdultAdultChildrenService
    {
        Task<IDataResult<List<AdultAdultChildren>>> GetAll();
        Task<IDataResult<AdultAdultChildren>> GetById(int adultAdultChildrenId);
        Task<IDataResult<List<AdultAdultChildren>>> GetByAdultId(int adultId);
        Task<IDataResult<List<AdultAdultChildren>>> GetByAdultChildrenId(int adultChildrenId);
        Task<IResult> Add(AdultAdultChildren adultAdultChildren);
        Task<IResult> Update(AdultAdultChildren adultAdultChildren);
        Task<IResult> Delete(AdultAdultChildren adultAdultChildren);
        Task<IResult> MultipleAddWithList(List<AdultAdultChildren> adultAdultChildrens);
    }
}
