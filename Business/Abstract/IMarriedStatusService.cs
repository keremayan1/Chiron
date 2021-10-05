using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IMarriedStatusService
    {
        Task<IDataResult<List<MarriedStatus>>> GetAll();
        Task<IDataResult<MarriedStatus>> GetById(int marriedStatusId);
        Task<IResult> Add(MarriedStatus marriedStatus);
        Task<IResult> Update(MarriedStatus marriedStatus);
        Task<IResult> Delete(MarriedStatus marriedStatus);

    }
}
