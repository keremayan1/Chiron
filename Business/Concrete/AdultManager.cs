using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Castle.DynamicProxy.Generators;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;

namespace Business.Concrete
{
    public class AdultManager : IAdultService
    {
        private IAdultDal _adultDal;
        private IPersonInformationService _personInformationService;
        private ITelephoneService _telephoneService;
        private IAdultChildrenService _adultChildrenService;
        private IAdultWifeService _adultWifeService;
        private IChildrenPersonService _childrenPersonService;
        private IAddressService _addressService;

        public AdultManager(IAdultDal adultDal, IPersonInformationService personInformationService, ITelephoneService telephoneService, IAdultChildrenService adultChildrenService, IAdultWifeService adultWifeService, IChildrenPersonService childrenPersonService, IAddressService addressService)
        {
            _adultDal = adultDal;
            _personInformationService = personInformationService;
            _telephoneService = telephoneService;
            _adultChildrenService = adultChildrenService;
            _adultWifeService = adultWifeService;
            _childrenPersonService = childrenPersonService;
            _addressService = addressService;
        }

        public async Task<IDataResult<List<Adult>>> GetAll()
        {
            return new SuccessDataResult<List<Adult>>(await _adultDal.GetAllAsync());
        }

        public async Task<IDataResult<Adult>> GetById(int adultId)
        {
            return new SuccessDataResult<Adult>(await _adultDal.GetAsync(a => a.Id == adultId));
        }

        public async Task<IResult> Add(Adult adult)
        {
            return new SuccessResult();
        }

        public async Task<IResult> Update(Adult adult)
        {
            await _adultDal.UpdateAsync(adult);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Adult adult)
        {
            await _adultDal.DeleteAsync(adult);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<AdultDetailDto>>> GetAdultDetails()
        {
            return new SuccessDataResult<List<AdultDetailDto>>(await _adultDal.GetAdultDetails());
        }

        
      //  [ValidationAspect(typeof(AdultDetailValidator))]
        public async Task<IResult> MultipleAdd(AdultDetailDto adultDetail)
        {
           

            var result = BusinessRules.Run(/*VerifyNationalId(adultDetail.Adults),
                CheckIfNationalIdExists(adultDetail.Adults.NationalId),*/CheckTelephoneNumberExists(adultDetail.Telephones),VerifyChildrenNationalId(adultDetail.AdultChildrenDetail),VerifyChildrenNationalId(adultDetail.AdultChildrenDetail),CheckIfChildrenNationalIdExists(adultDetail.AdultChildrenDetail));
            if (result!=null)
            {
                return result;
            }
          
            await _adultDal.AddAsync(adultDetail.Adults);
            await HaveChildren(adultDetail);
            await HaveWife(adultDetail);
           
            await _telephoneService.MultipleAddWithList(adultDetail.Telephones);
            await _addressService.MultipleAddWithList(adultDetail.Addresses);
            return new SuccessResult();
        }

      

        private async Task HaveWife(AdultDetailDto adultDetail)
        {
            if (adultDetail.DoesHaveWife)
            {
                GetAdultWifeId(adultDetail);
                await _adultWifeService.Add(adultDetail.AdultWifes);

            }
        }

        private static void GetAdultWifeId(AdultDetailDto adultDetail)
        {
            adultDetail.AdultWifes.WifeId = adultDetail.Adults.Id;
        }

        private async Task HaveChildren(AdultDetailDto adultDetail)
        {
            if (adultDetail.DoesHaveChildren)
            {
                await _adultChildrenService.MultipleAddAdultChildrenList(adultDetail.AdultChildrenDetail);
                GetAdultDetail(adultDetail);
                await _childrenPersonService.Add(adultDetail.ChildrenPerson);
            }
        }

        private static void GetAdultDetail(AdultDetailDto adultDetail)
        {
            adultDetail.ChildrenPerson.EducationStatusId = adultDetail.Adults.EducationStatusId;
            foreach (var adultChildrenDetailDto in adultDetail.AdultChildrenDetail)
            {
                foreach (var children in adultChildrenDetailDto.Childrens)
                {
                    adultDetail.ChildrenPerson.ChildrenId = children.Id;
                    
                }
                adultDetail.ChildrenPerson.FamilyStatusId = adultChildrenDetailDto.FamilyStatusId;
            }
        }

        
        public IResult CheckIfNationalIdExists(string nationalId)
        {
            //var result = _personInformationService.CheckIfNationalIdExists(nationalId);
            //if (!result.Success)
            //{
            //    return new ErrorResult(result.Message);
            //}

            return new SuccessResult();
        }

        public IResult VerifyNationalId(Adult adult)
        {
            //var result = _personInformationService.VerifyNationalId(adult);
            //if (!result.Success)
            //{
            //    return new ErrorResult(result.Message);
            //}

            return new SuccessResult();
        }

        public IResult VerifyChildrenNationalId(List<AdultChildrenDetailDto> adultChildrenDetail)
        {
            //foreach (var adultChildrenDetailDto in adultChildrenDetail)
            //{
            //    foreach (var children in adultChildrenDetailDto.Childrens)
            //    {
            //        var result = _personInformationService.VerifyNationalId(children);
            //        if (!result.Success)
            //        {
            //            return new ErrorResult(result.Message);
            //        }

            //    }
            //}
            return new SuccessResult();
        }

        public IResult CheckIfChildrenNationalIdExists(List<AdultChildrenDetailDto> adultChildrenDetail)
        {
            //foreach (var adultChildrenDetailDto in adultChildrenDetail)
            //{
            //    foreach (var children in adultChildrenDetailDto.Childrens)
            //    {
            //        var result = _personInformationService.CheckIfNationalIdExists(children.NationalId);
            //        if (!result.Success)
            //        {
            //            return new ErrorResult(result.Message);
            //        }
            //    }
            //}

            return new SuccessResult();
        }
      
        
        public IResult CheckTelephoneNumberExists(List<Telephone> telephoneNumber)
        {
            foreach (var telephone in telephoneNumber)
            {
                var result = _telephoneService.CheckTelephoneNumberExists(telephone.TelephoneNumber);
                if (!result.Success)
                {
                    return new ErrorResult(result.Message);
                }


            }
            return new SuccessResult();

        }

        public IResult CheckTelephoneNumberExists(string telephoneNumber)
        {
            throw new NotImplementedException();
        }

        public IResult CheckTelephoneListNumberExists(List<Telephone> telephones)
        {
            throw new NotImplementedException();
        }
    }
}
