using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Castle.Components.DictionaryAdapter;
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
      
        private ITelephoneService _telephoneService;
        private IAdultChildrenService _adultChildrenService;
        private IAdultWifeService _adultWifeService;
        private IChildrenPersonService _childrenPersonService;
        private IAddressService _addressService;
        private IContactInformationService _contactInformationService;
        private IAdultAdultChildrenService _adultAdultChildrenService;


        public AdultManager(IAdultDal adultDal, ITelephoneService telephoneService, IAdultChildrenService adultChildrenService, IAdultWifeService adultWifeService, IChildrenPersonService childrenPersonService, IAddressService addressService, IContactInformationService contactInformationService, IAdultAdultChildrenService adultAdultChildrenService)
        {
            _adultDal = adultDal;
            
            _telephoneService = telephoneService;
            _adultChildrenService = adultChildrenService;
            _adultWifeService = adultWifeService;
            _childrenPersonService = childrenPersonService;
            _addressService = addressService;
            _contactInformationService = contactInformationService;
            _adultAdultChildrenService = adultAdultChildrenService;
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

        
      // [ValidationAspect(typeof(AdultDetailValidator))]
        public async Task<IResult> AdultDetailDtoAdd(AdultDetailDto adultDetail)
        {
            var result = BusinessRules.Run(/*VerifyNationalId(adultDetail.Adults),
                CheckIfNationalIdExists(adultDetail.Adults.NationalId),CheckTelephoneListNumberExists(adultDetail.Telephones)*/);
            if (result!=null)
            {
                return result;
            }
          
            await _adultDal.AddAsync(adultDetail.Adults);
            await HaveChildren(adultDetail);
            await HaveWife(adultDetail);
            await AdultAdultChildrenAdd(adultDetail);
            await _telephoneService.MultipleAddWithList(adultDetail.Telephones);
            await _addressService.MultipleAddWithList(adultDetail.Addresses);
            return new SuccessResult();
        }

        private async Task AdultAdultChildrenAdd(AdultDetailDto adultDetail)
        {
            foreach (var adultChildren in adultDetail.AdultChildrenDetail)
            {
                foreach (var adultChild in adultChildren.AdultChildren)
                {
                    await AddAdultAdultChildren(adultDetail, adultChild);
                }
            }
        }

        private async Task AddAdultAdultChildren(AdultDetailDto adultDetail, AdultChildren adultChild)
        {
            await _adultAdultChildrenService.Add(new AdultAdultChildren
            {
                AdultId = adultDetail.Adults.Id,
                AdultChildrenId = adultChild.Id
            });
        }

        private async Task AdultAdultChildrenUpdate(AdultDetailDto adultDetail)
        {
            foreach (var adultChildren in adultDetail.AdultChildrenDetail)
            {
                foreach (var adultChild in adultChildren.AdultChildren)
                {
                    await UpdateAdultAdultChildren(adultDetail, adultChild);
                }
            }
        }

        private async Task UpdateAdultAdultChildren(AdultDetailDto adultDetail, AdultChildren adultChild)
        {
            await _adultAdultChildrenService.Update(new AdultAdultChildren
            {
                AdultId = adultDetail.Adults.Id,
                AdultChildrenId = adultChild.Id
            });
        }

        private async Task HaveWife(AdultDetailDto adultDetail)
        {
            if (adultDetail.DoesHaveWife)
            {
                GetAdultWifeId(adultDetail);
                await _adultWifeService.Add(adultDetail.AdultWifes);

            }
        }
        [ValidationAspect(typeof(AdultChildrenDetailValidator))]
        private async Task HaveChildren(AdultDetailDto adultDetail)
        {
            if (adultDetail.DoesHaveChildren)
            {
                await _adultChildrenService.MultipleAddAdultChildrenList(adultDetail.AdultChildrenDetail);
            }
        }
        private static void GetAdultWifeId(AdultDetailDto adultDetail)
        {
            adultDetail.AdultWifes.WifeId = adultDetail.Adults.Id;
        }

        public IResult CheckIfNationalIdExists(string nationalId)
        {
            var result = _contactInformationService.CheckIfNationalIdExists(nationalId);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccessResult();
        }

        public IResult VerifyNationalId(Adult adult)
        {
            var result = _contactInformationService.VerifyNationalId(adult);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccessResult();
        }
        public IResult CheckTelephoneListNumberExists(List<Telephone> telephoneNumber)
        {
            var result = _telephoneService.CheckTelephoneListNumberExists(telephoneNumber);
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
