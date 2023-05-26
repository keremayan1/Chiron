using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Adapters.PersonService;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class ContactInformationManager:IContactInformationService
   {
       private IContactInformationDal _contactInformationDal;
       private IKpsService _kpsService;

       public ContactInformationManager(IContactInformationDal contactInformationDal, IKpsService kpsService)
       {
           _contactInformationDal = contactInformationDal;
           _kpsService = kpsService;
       }

       public async Task<IDataResult<List<ContactInformation>>> GetAll()
       {
           return new SuccessDataResult<List<ContactInformation>>(await _contactInformationDal.GetAllAsync());
       }

        public async Task<IDataResult<ContactInformation>> GetById(int contactInformationId)
        {
            return new SuccessDataResult<ContactInformation>(
                await _contactInformationDal.GetAsync(ci => ci.Id == contactInformationId));
        }

        public async Task<IResult> Add(ContactInformation contactInformation)
        {
            await _contactInformationDal.AddAsync(contactInformation);
            return new SuccessResult();
        }

        public async Task<IResult> Update(ContactInformation contactInformation)
        {
            await _contactInformationDal.UpdateAsync(contactInformation);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(ContactInformation contactInformation)
        {
            await _contactInformationDal.DeleteAsync(contactInformation);
            return new SuccessResult();
        }

        public async Task<IResult> MultipleAddWithList(List<ContactInformation> contactInformations)
        {
            await _contactInformationDal.MultipleAddAsyncWithList(contactInformations);
            return new SuccessResult();
        }

        public async Task<IResult> MultipleDeleteWithList(List<ContactInformation> contactInformations)
        {
            await _contactInformationDal.MultipleDeleteAsyncWithList(contactInformations);
            return new SuccessResult();
        }

        public async Task<IResult> MultipleUpdateWithList(List<ContactInformation> contactInformation)
        {
            await _contactInformationDal.MultipleUpdateAsyncWithList(contactInformation);
            return new SuccessResult();
        }

        public IResult CheckIfNationalIdExists(string nationalId)
        {
            var result = _contactInformationDal.Any(ci => ci.NationalId == nationalId);
            if (result)
            {
                return new ErrorResult("Hata Boyle Bir Kullanici Sistemde Vardir");
            }

            return new SuccessResult();
        }

        public IResult VerifyNationalId(ContactInformation contactInformation)
        {
            var result = _kpsService.Verify(contactInformation).Result;
            if (!result)
            {
                return new ErrorResult("Hatali TC");
            }

            return new SuccessResult();

        }
   }
}
