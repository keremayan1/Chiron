using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Rules;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        private ITelephoneService _telephoneService;
        private IChildrenPersonService _childrenPersonService;
        private IAddressService _addressService;
       


        public ChildrenManager(IChildrenDal childrenDal, IPersonService personService, IPersonInformationService personInformationService, IGenderService genderService, IChildrenPersonDal childrenPersonDal, ITelephoneService telephoneService, IChildrenPersonService childrenPersonService, IAddressService addressService)
        {
            _childrenDal = childrenDal;
            _personService = personService;
            _personInformationService = personInformationService;
            _telephoneService = telephoneService;
            _childrenPersonService = childrenPersonService;
            _addressService = addressService;
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
            var result = BusinessRules.Run(/*VerifyNationalId(children), CheckIfNationalIdExists(children.NationalId)*/);
            if (result != null)
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
            return new SuccessDataResult<List<ChildrenDetail>>();
        }
        [ValidationAspect(typeof(ChildrenDetailValidator))]
        public async Task<IResult> MultipleAdd(List<ChildrenDetail> childrenDetails)
        {
          
            foreach (var childrenDetail in childrenDetails)
            {
                var result = BusinessRules.Run(/*CheckTelephoneNumberExists(childrenDetail.TelephoneNumber),CheckIfNationalIdExists(childrenDetail.NationalId)*/);
                if (result != null)
                {
                    return result;
                }
                await _childrenDal.MultipleAddAsyncWithList(childrenDetail.Children);
                MultipleAddInChildrenPerson(childrenDetail);
                await _childrenPersonService.MultipleAddWithList(childrenDetail.ChildrenPersonDetail);
                MultipleAddInTelephonesOnChildren(childrenDetail);
                await _telephoneService.MultipleAdd(childrenDetail.Telephones);
            }

            return new SuccessResult();
        }

        private static void MultipleAddInChildrenPerson(ChildrenDetail childrenDetail)
        {
            foreach (var c in childrenDetail.ChildrenPersonDetail)
            {
                foreach (var childrenDetailChild in childrenDetail.Children)
                {
                    c.ChildrenId = childrenDetailChild.Id;
                }
            }
        }

        private static void MultipleAddInTelephonesOnChildren(ChildrenDetail childrenDetail)
        {
            foreach (var telephone in childrenDetail.Telephones)
            {
                foreach (var childrenDetailChild in childrenDetail.Children)
                {
                    telephone.PersonInformationId = childrenDetailChild.Id;
                }
            }
        }

        public async Task<IResult> MultipleDelete(List<ChildrenDetail> childrenDetails)
        {
            foreach (var childrenDetail in childrenDetails)
            {
                var children = new Children
                {

                };
                await _childrenDal.DeleteAsync(children);
            }

            return new SuccessResult();
        }

        public async Task<IResult> MultipleUpdate(List<ChildrenDetail> childrenDetails)
        {
            foreach (var childrenDetail in childrenDetails)
            {
                var children = new Children
                {
                };
                await _childrenDal.UpdateAsync(children);
            }

            return new SuccessResult();
        }

        public async Task<IDataResult<List<GetByChildrenDetailDto>>> GetChildrenDetailss()
        {
            return new SuccessDataResult<List<GetByChildrenDetailDto>>(await _childrenDal.GetChildrenDetails());
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

        public IResult CheckTelephoneNumberExists(string telephoneNumber)
        {
            var result = _telephoneService.CheckTelephoneNumberExists(telephoneNumber);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccessResult();
        }
      
    }
}
