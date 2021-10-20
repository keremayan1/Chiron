using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IAdultWifeService
    {
        Task<IDataResult<List<AdultWife>>> GetAll();
        Task<IDataResult<AdultWife>> GetById(int adultWifeId);
        Task<IResult> Add(AdultWife adultWife);

        Task<IResult> Update(AdultWife adultWife);
        Task<IResult> Delete(AdultWife adultWife);
    }
}
