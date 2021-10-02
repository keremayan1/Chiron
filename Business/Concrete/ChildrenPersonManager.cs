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
        private IPersonInformationService _personInformationService;

        public ChildrenPersonManager(IChildrenPersonDal childrenPersonDal, IChildrenService childrenService, IAddressService addressService, ITelephoneService telephoneService, IKpsService kpsService, IPersonInformationService personInformationService)
        {
            _childrenPersonDal = childrenPersonDal;
            _addressService = addressService;
            _telephoneService = telephoneService;
          
            _personInformationService = personInformationService;
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

        [ValidationAspect(typeof(ChildrenPersonValidator))]
        public async Task<IResult> AddAsync(ChildrenPersonDetail childrenPersonDetail)
        {
            var childrenPerson = ChildrenPerson(childrenPersonDetail);
            var address = Address(childrenPersonDetail);
            var telephone = Telephone(childrenPersonDetail);
            var result = BusinessRules.Run( /*VerifyNationalId(childrenPerson),*/CheckIfNationalIdExists(childrenPersonDetail.NationalId), CheckTelephoneNumberExists(childrenPersonDetail.TelephoneNumber));
            if (result!=null)
            {
                return result;
            }
            childrenPerson.ChildrenId = childrenPersonDetail.ChildrenId;
            childrenPerson.Id = childrenPersonDetail.PersonInformationId;
            await _childrenPersonDal.AddAsync(childrenPerson);
            address.PersonInformationId = childrenPerson.Id;
            await _addressService.Add(address);
            telephone.PersonInformationId = childrenPerson.Id;
            await _telephoneService.Add(telephone);
            return new SuccessResult("Basarili");
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
       

        private static ChildrenPerson ChildrenPerson(ChildrenPersonDetail childrenPersonDetail)
        {
            var childrenPerson = new ChildrenPerson
            {
                Id = childrenPersonDetail.PersonInformationId,
                EducationStatusId = childrenPersonDetail.EducationStatusId,
                FamilyStatusId = childrenPersonDetail.FamilyStatusId,
                JobsId = childrenPersonDetail.JobsId,
                NationalId = childrenPersonDetail.NationalId,
                FirstName = childrenPersonDetail.FirstName,
                LastName = childrenPersonDetail.LastName,
                DateOfBirth = childrenPersonDetail.DateOfBirth,
                PersonGenderId = childrenPersonDetail.PersonGenderId
            };
            return childrenPerson;
        }
        public async Task<IDataResult<List<ChildrenPersonDetail>>> GetChildrenPersonDetails()
        {
            return new SuccessDataResult<List<ChildrenPersonDetail>>(await  _childrenPersonDal.GetChildrenPersonDetails());
        }

        public async Task<IResult> MultipleAdd2(ChildrenPersonDetail[] childrenPersonDetails)
        {
            foreach (var childrenPersonDetail in childrenPersonDetails)
            {
                var childrenPerson = ChildrenPerson(childrenPersonDetail);
                var address = Address(childrenPersonDetail);
                var telephone = Telephone(childrenPersonDetail);
                var result = BusinessRules.Run(/*VerifyNationalId(childrenPerson),CheckIfNationalIdExists(childrenPersonDetail.NationalId), CheckIfTelephoneNumberExists(childrenPersonDetail.TelephoneNumber)*/);
                if (result != null)
                {
                    return result;
                }
                childrenPerson.ChildrenId = childrenPersonDetail.ChildrenId;
                childrenPerson.Id = childrenPersonDetail.PersonInformationId;
                await _childrenPersonDal.AddAsync(childrenPerson);
                address.PersonInformationId = childrenPerson.Id;
                await _addressService.Add(address);
                telephone.PersonInformationId = childrenPerson.Id;
                await _telephoneService.Add(telephone);
            }

            return new SuccessResult();
        }
        /// <summary>
        /// Rule process
        /// </summary>
        /// <param name="childrenPerson"></param>
        /// <returns></returns>
        public IResult VerifyNationalId(ChildrenPerson childrenPerson)
        {
            var result = _personInformationService.VerifyNationalId(childrenPerson);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
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
        /// <summary>
        /// Entities process
        /// </summary>
        /// <param name="childrenPersonDetail"></param>
        /// <returns></returns>
        private static Telephone Telephone(ChildrenPersonDetail childrenPersonDetail)
        {
            var telephone = new Telephone
            {
                TelephoneNumber = childrenPersonDetail.TelephoneNumber
            };
            return telephone;
        }

        private static Address Address(ChildrenPersonDetail childrenPersonDetail)
        {
            var address = new Address
            {
                AddressName = childrenPersonDetail.AddressName,
            };
            return address;
        }


    }
}
