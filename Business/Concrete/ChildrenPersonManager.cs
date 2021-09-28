using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Adapters.PersonService;
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
        private IKpsService _kpsService;

        public ChildrenPersonManager(IChildrenPersonDal childrenPersonDal, IChildrenService childrenService, IAddressService addressService, ITelephoneService telephoneService, IKpsService kpsService)
        {
            _childrenPersonDal = childrenPersonDal;
           
            _addressService = addressService;
            _telephoneService = telephoneService;
            _kpsService = kpsService;
        }


        public async Task<IDataResult<List<ChildrenPerson>>> GetAll()
        {
            return new SuccessDataResult<List<ChildrenPerson>>(await _childrenPersonDal.GetAllAsync());
        }

        public async Task<IDataResult<ChildrenPerson>> GetById(int childrenPersonId)
        {
            return new SuccessDataResult<ChildrenPerson>(
                await _childrenPersonDal.GetAsync(ch => ch.Id == childrenPersonId));
        }

        public async Task<IResult> Add(ChildrenPerson childrenPerson)
        {
          
            await _childrenPersonDal.AddAsync(childrenPerson);
             


            return new SuccessResult("Basarili");
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

        public async Task<IResult> AddAsync(ChildrenPersonDetail childrenPersonDetail)
        {

            var childrenPerson = ChildrenPerson(childrenPersonDetail);
            var address = Address(childrenPersonDetail);
            var telephone = Telephone(childrenPersonDetail);
            var result = BusinessRules.Run(CheckIfNationalIdExists(childrenPersonDetail.NationalId), CheckIfTelephoneNumberExists(childrenPersonDetail.TelephoneNumber),VerifyNationalId(childrenPerson));
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

        public IResult CheckIfTelephoneNumberExists(long telephoneNumber)
        {
            var result = _telephoneService.CheckTelephoneNumberExists(telephoneNumber);
            if (!result.Success)
            {
                return new ErrorResult("Sistemde Boyle Telefon No Vardir");
            }

            return new SuccessResult();
        }
        public IResult CheckIfNationalIdExists(string nationalId)
        {
            var result = _childrenPersonDal.Any(p => p.NationalId == nationalId);
            if (result)
            {
                return new ErrorResult("sistemde Boyle bir kullanici vardir");
            }

            return new SuccessResult();
        }

        
       
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
            return new SuccessDataResult<List<ChildrenPersonDetail>>(await  _childrenPersonDal.GetChildrenPersonDetails()
              );
        }

        public async Task<IResult> MultipleChildrenPersonAdd(ChildrenPerson[] childrenPersons)
        {
          
            await _childrenPersonDal.MultipleAddAsync(childrenPersons);
            
            return new SuccessResult();
        }

        
        public IResult VerifyNationalId(PersonInformation personInformation)
        {
            var result = _kpsService.Verify(personInformation).Result;
            if (!result)
            {
                return new ErrorResult("Hatali TC");
            }

            return new SuccessResult();
        }


    }
}
