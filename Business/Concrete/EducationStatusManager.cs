using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class EducationStatusManager : IEducationStatusService
    {
        private IEducationStatusDal _educationStatusDal;

        public EducationStatusManager(IEducationStatusDal educationStatusDal)
        {
            _educationStatusDal = educationStatusDal;
        }

        public async Task<IDataResult<List<EducationStatus>>> GetAll()
        {
            return new SuccessDataResult<List<EducationStatus>>(await _educationStatusDal.GetAllAsync());
        }

        public async Task<IDataResult<EducationStatus>> GetByEducationId(int educationId)
        {
            return new SuccessDataResult<EducationStatus>(
                await _educationStatusDal.GetAsync(es => es.Id == educationId));
        }

        public async Task<IResult> Add(EducationStatus educationStatus)
        {
            var result = BusinessRules.Run(CheckIfEducationStatusNameExists(educationStatus.Name));
            if (result!=null)
            {
                return result;
            }
            await _educationStatusDal.AddAsync(educationStatus);
            return new SuccessResult();
        }

        public async Task<IResult> Update(EducationStatus educationStatus)
        {
            await _educationStatusDal.UpdateAsync(educationStatus);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(EducationStatus educationStatus)
        {
         await   _educationStatusDal.DeleteAsync(educationStatus);
         return new SuccessResult();
        }

        public IResult CheckIfEducationStatusNameExists(string educationStatusName)
        {
            var result = _educationStatusDal.Any(es => es.Name.ToLower() == educationStatusName.ToLower());
            if (result)
            {
                return new ErrorResult("Boyle bir Ogrenim Durumu vardir");
            }

            return new SuccessResult();
        }
    }
}
