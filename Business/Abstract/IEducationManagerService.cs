using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IEducationStatusService
   {
       Task<IDataResult<List<EducationStatus>>> GetAll();
       Task<IDataResult<EducationStatus>> GetByEducationId(int educationId);
       Task<IResult> Add(EducationStatus educationStatus);
       Task<IResult> Update(EducationStatus educationStatus);
       Task<IResult> Delete(EducationStatus educationStatus);
   }
}
