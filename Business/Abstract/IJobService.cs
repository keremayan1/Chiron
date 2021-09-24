using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IJobService
    {
        Task<IDataResult<List<Job>>> GetAll();
        Task<IDataResult<Job>> GetByJobId(int jobId);
        Task<IResult> Add(Job job);
        Task<IResult> Update(Job job);
        Task<IResult> Delete(Job job);
    }
}
