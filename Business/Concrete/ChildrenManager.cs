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
using Entities.Concrete.Dto;

namespace Business.Concrete
{
    public class ChildrenManager : IChildrenService
    {
        private IChildrenDal _childrenDal;
        private IPersonService _personService;
        private IPersonInformationService _personInformationService;
        private IChildrenPersonDal _childrenPersonDal;


        public ChildrenManager(IChildrenDal childrenDal, IPersonService personService, IPersonInformationService personInformationService, IGenderService genderService, IChildrenPersonDal childrenPersonDal)
        {
            _childrenDal = childrenDal;
            _personService = personService;
            _personInformationService = personInformationService;
            _childrenPersonDal = childrenPersonDal;
        }

        public async Task<IDataResult<List<Children>>> GetAll()
        {
            return new SuccessDataResult<List<Children>>(await _childrenDal.GetAllAsync());
        }

        public IDataResult<Children> GetById(int childrenId)
        {

            return new SuccessDataResult<Children>(_childrenDal.GetAsync(c => c.Id == childrenId).Result);
        }

        public async Task<IResult> Add(Children children)
        {
            var result = BusinessRules.Run(VerifyNationalId(children), CheckIfNationalIdExists(children.NationalId));
            if (result!=null)
            {
                return result;
            }
            await _childrenDal.AddAsync(children);
            return new SuccessResult("Basarili");
        }
        public async Task<IResult> Update(Children children)
        {
            await _childrenDal.UpdateAsync(children);
            return new SuccessResult("Basarili");
        }

        public async Task<IResult> Delete(Children children)
        {
            await _childrenDal.DeleteAsync(children);
            return new SuccessResult();

        }

        public IDataResult<List<ChildrenDetail>> GetChildrenDetails()
        {
            return new SuccessDataResult<List<ChildrenDetail>>(_childrenDal.GetChildrenDetails().Result);
        }

       
        public IResult IsPersonAvaliable(int personId)
        {
            var result = _personService.GetById(personId).Result;
            if (result != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IResult CheckIfNationalIdExists(string nationalId)
        {
            var result = _personInformationService.CheckIfNationalIdExists(nationalId);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccessResult();
        }

        public IResult VerifyNationalId(Children children)
        {
            var result = _personInformationService.VerifyNationalId(children);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccessResult();
        }
    }
}
