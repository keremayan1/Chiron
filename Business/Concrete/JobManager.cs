using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class JobManager : IJobService
    {
        private IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public async Task<IDataResult<List<Job>>> GetAll()
        {
            return new ErrorDataResult<List<Job>>(await _jobDal.GetAllAsync());
        }

        public async Task<IDataResult<Job>> GetByJobId(int jobId)
        {
            var result = BusinessRules.Run(CheckIfJobIdExists(jobId));
            if (result != null)
            {
                return new ErrorDataResult<Job>(result.Message);
            }
            return new SuccessDataResult<Job>(await _jobDal.GetAsync(j => j.Id == jobId));
        }

        public async Task<IResult> Add(Job job)
        {
            var result = BusinessRules.Run(CheckIfJobNameExists(job.Name));
            if (result != null)
            {
                return result;
            }
            await _jobDal.AddAsync(job);
            return new SuccessResult();
        }

        public async Task<IResult> Update(Job job)
        {
            var result = BusinessRules.Run(CheckIfJobNameExists(job.Name), CheckIfJobIdExists(job.Id));
            if (result != null)
            {
                return result;
            }
            await _jobDal.UpdateAsync(job);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Job job)
        {
            var result = BusinessRules.Run(CheckIfJobIdExists(job.Id));
            if (result != null)
            {
                return result;
            }
            await _jobDal.DeleteAsync(job);
            return new SuccessResult();
        }

        public IResult CheckIfJobNameExists(string jobName)
        {
            var result = _jobDal.Any(j => j.Name.ToLower() == jobName.ToLower());
            if (result)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IResult CheckIfJobIdExists(int jobId)
        {
            var result = _jobDal.AnyAsync(j => j.Id == jobId);
            if (!result.Result)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
