using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IReligionService
    {
        Task<IDataResult<List<Religion>>> GetAll();
        Task<IDataResult<Religion>> GetById(int religionId);
        Task<IResult> Add(Religion religion);
        Task<IResult> Update(Religion religion);
        Task<IResult> Delete(Religion religion);

        Task<IResult> MultipleAdd2(List<Religion> religions);
    }
}
