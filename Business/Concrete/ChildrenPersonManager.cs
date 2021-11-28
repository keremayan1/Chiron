using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Adapters.PersonService;
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
    public class ChildrenPersonManager : IChildrenPersonService
    {
        private IChildrenPersonDal _childrenPersonDal;
        private IAddressService _addressService;
        private ITelephoneService _telephoneService;
        

        public ChildrenPersonManager(IChildrenPersonDal childrenPersonDal, IAddressService addressService, ITelephoneService telephoneService)
        {
            _childrenPersonDal = childrenPersonDal;
            _addressService = addressService;
            _telephoneService = telephoneService;
          
            
        }

        /// <summary>
        /// CRUD process
        /// </summary>
        /// <returns></returns>
        public async Task<IDataResult<List<ChildrenPerson>>> GetAll()
        {
            return new SuccessDataResult<List<ChildrenPerson>>(await _childrenPersonDal.GetAllAsync());
        }

        public async Task<IDataResult<ChildrenPerson>> GetById(int childrenPersonId)
        {
            return new SuccessDataResult<ChildrenPerson>(
                await _childrenPersonDal.GetAsync(ch => ch.Id == childrenPersonId));
        }

       
        public async Task<IResult> Update(ChildrenPerson childrenPerson)
        {
            await _childrenPersonDal.UpdateAsync(childrenPerson);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(ChildrenPerson childrenPerson)
        {
            await _childrenPersonDal.DeleteAsync(childrenPerson);
            return new SuccessResult();
        }
      
     
     
        public async Task<IResult> MultipleAddWithList(List<ChildrenPersonDetail> childrenPersonDetails)
        {
            foreach (var childrenPersonDetail in childrenPersonDetails)
            {
                //var result = BusinessRules.Run(CheckTelephoneNumberExists(childrenPersonDetail.Telephones));
                //if (result != null)
                //{
                //    return result;
                //}
                await _childrenPersonDal.AddAsync(childrenPersonDetail.ChildrenPerson);
                MultipleAddInAdressesOnChildrenPerson(childrenPersonDetail, childrenPersonDetail.ChildrenPerson);
                await _addressService.MultipleAddWithList(childrenPersonDetail.Addresses);
                MultipleAddInTelephonesOnChildrenPerson(childrenPersonDetail, childrenPersonDetail.ChildrenPerson);
                await _telephoneService.MultipleAddWithList(childrenPersonDetail.Telephones);
            }

            return new SuccessResult();
        }

        public async Task<IResult> MultipleDeleteWithList(List<ChildrenPersonDetail> childrenPersonDetails)
        {
            foreach (var childrenPersonDetail in childrenPersonDetails)
            {
               
                var result = BusinessRules.Run(CheckTelephoneNumberExists(childrenPersonDetail.Telephones));
                if (result != null)
                {
                    return result;
                }
                await _childrenPersonDal.DeleteAsync(childrenPersonDetail.ChildrenPerson);
                MultipleAddInAdressesOnChildrenPerson(childrenPersonDetail, childrenPersonDetail.ChildrenPerson);
                await _addressService.MultipleDeleteWithList(childrenPersonDetail.Addresses);
                MultipleAddInTelephonesOnChildrenPerson(childrenPersonDetail, childrenPersonDetail.ChildrenPerson);
                await _telephoneService.MultipleDeleteWithList(childrenPersonDetail.Telephones);
            }

            return new SuccessResult();
        }

        public async Task<IResult> MultipleUpdateWithList(List<ChildrenPersonDetail> childrenPersonDetails)
        {
            foreach (var childrenPersonDetail in childrenPersonDetails)
            {
              
                var result = BusinessRules.Run( CheckTelephoneNumberExists(childrenPersonDetail.Telephones));
                if (result != null)
                {
                    return result;
                }
                await _childrenPersonDal.UpdateAsync(childrenPersonDetail.ChildrenPerson);
                MultipleAddInAdressesOnChildrenPerson(childrenPersonDetail, childrenPersonDetail.ChildrenPerson);
                await _addressService.MultipleUpdateWithList(childrenPersonDetail.Addresses);
                MultipleAddInTelephonesOnChildrenPerson(childrenPersonDetail, childrenPersonDetail.ChildrenPerson);
                await _telephoneService.MultipleUpdateWithList(childrenPersonDetail.Telephones);
            }

            return new SuccessResult();
        }
        [ValidationAspect(typeof(ChildrenPersonDetailValidator))]
        public async Task<IResult> AddChildrenPersonDetail(ChildrenPersonDetail childrenPersonDetail)
        {
          
            var result = BusinessRules.Run(CheckTelephoneNumberExists(childrenPersonDetail.Telephones));
            if (result != null)
            {
                return result;
            }
            await _childrenPersonDal.AddAsync(childrenPersonDetail.ChildrenPerson);
            MultipleAddInAdressesOnChildrenPerson(childrenPersonDetail, childrenPersonDetail.ChildrenPerson);
            await _addressService.MultipleAddWithList(childrenPersonDetail.Addresses);
            MultipleAddInTelephonesOnChildrenPerson(childrenPersonDetail, childrenPersonDetail.ChildrenPerson);
            await _telephoneService.MultipleAddWithList(childrenPersonDetail.Telephones);
            return new SuccessResult();
        }

        public async Task<IResult> Add(ChildrenPerson childrenPerson)
        {
            await _childrenPersonDal.AddAsync(childrenPerson);
            return new SuccessResult();
        }

        public async Task<IResult> AddWithList(List<ChildrenPerson> childrenPersons)
        {
            await _childrenPersonDal.MultipleAddAsyncWithList(childrenPersons);
            return new SuccessResult();
        }

     
       

        /// <summary>
        /// Veri Alma
        /// </summary>
        /// <param name="childrenPersonDetail"></param>
        /// <param name="childrenPerson"></param>
        private  static  void MultipleAddInAdressesOnChildrenPerson(ChildrenPersonDetail childrenPersonDetail, ChildrenPerson childrenPerson)
        {
            foreach (var addresses in childrenPersonDetail.Addresses)
            {
                addresses.PersonInformationId = childrenPerson.Id;
            }
        }

        public  static void MultipleAddInTelephonesOnChildrenPerson(ChildrenPersonDetail childrenPersonDetail, ChildrenPerson childrenPerson)
        {
            foreach (var telephones in childrenPersonDetail.Telephones)
            {
                telephones.PersonInformationId = childrenPerson.Id;
            }
        }

        /// <summary>
        /// Rule process
        /// </summary>
        /// <param name="childrenPerson"></param>
        /// <returns></returns>
     
        public IResult CheckTelephoneNumberExists(List<Telephone> telephoneNumber)
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

        public IResult CheckTelephoneListNumberExists(List<Telephone> telephones)
        {
            var result = _telephoneService.CheckTelephoneListNumberExists(telephones);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccessResult();
        }
    }
}
