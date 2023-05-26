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
using Entities.Concrete.Dto.SelectProcess;

namespace Business.Concrete
{
    public class AdultManager : IAdultService
    {
        private IAdultDal _adultDal;

        private ITelephoneService _telephoneService;
        private IAdultChildrenService _adultChildrenService;
        private IAdultWifeService _adultWifeService;
        private IAddressService _addressService;
        private IContactInformationService _contactInformationService;
        private IAdultAdultChildrenService _adultAdultChildrenService;
        public AdultManager(IAdultDal adultDal, ITelephoneService telephoneService, IAdultChildrenService adultChildrenService, IAdultWifeService adultWifeService, IAddressService addressService, IContactInformationService contactInformationService, IAdultAdultChildrenService adultAdultChildrenService)
        {
            _adultDal = adultDal;
            _telephoneService = telephoneService;
            _adultChildrenService = adultChildrenService;
            _adultWifeService = adultWifeService;
            _addressService = addressService;
            _contactInformationService = contactInformationService;
            _adultAdultChildrenService = adultAdultChildrenService;
        }
        public async Task<IDataResult<Adult>> GetById(int adultId)
        {
            var result = await _adultDal.GetAsync(a => a.Id == adultId);
            await _telephoneService.GetByPersonInformationId(result.Id);
            return new SuccessDataResult<Adult>(result);
        }
        public async Task<IDataResult<List<AdultDetailWithRead>>> GetAdultDetail()
        {
            return new SuccessDataResult<List<AdultDetailWithRead>>(await _adultDal.GetAdultsDetail());
        }

        public async Task<IResult> Delete(int id)
        {
            var result = await _adultDal.GetAsync(x => x.Id == id);
            result.IsActive = false;
          await  _adultDal.UpdateAsync(result);
          return new SuccessResult("basarili");
        }

        [ValidationAspect(typeof(AdultDetailValidator))]
        public async Task<IResult> AdultDetailDtoAdd(AdultDetailDto adultDetail)
        {
            var result = BusinessRules.Run(/*VerifyNationalId(adultDetail.Adults),
                CheckIfNationalIdExists(adultDetail.Adults.NationalId),CheckTelephoneListNumberExists(adultDetail.Telephones)*/);
            if (result != null)
            {
                return result;
            }

            await _adultDal.AddAsync(adultDetail.Adults);
            await HaveWife(adultDetail);
            await HaveChildren(adultDetail);
            await AdultAdultChildrenAdd(adultDetail);
            AdultTelephones(adultDetail);
            await _telephoneService.MultipleAddWithList(adultDetail.Telephones);
            AdultAddresses(adultDetail);
            await _addressService.MultipleAddWithList(adultDetail.Addresses);
             return new SuccessResult("Basarili");
        }

        private static void AdultAddresses(AdultDetailDto adultDetail)
        {
            foreach (var adultDetailAddress in adultDetail.Addresses)
            {
                adultDetailAddress.PersonInformationId = adultDetail.Adults.Id;
            }
        }

        private static void AdultTelephones(AdultDetailDto adultDetail)
        {
            foreach (var telephone in adultDetail.Telephones)
            {
                telephone.PersonInformationId = adultDetail.Adults.Id;
            }
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
