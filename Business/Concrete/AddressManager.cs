using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class AddressManager:IAddressService
   {
       private IAddressDal _addressDal;

       public AddressManager(IAddressDal addressDal)
       {
           _addressDal = addressDal;
       }

       public async Task<IDataResult<List<Address>>> GetAll()
       {
           return new SuccessDataResult<List<Address>>(await _addressDal.GetAllAsync());
       }

        public async Task<IDataResult<Address>> GetById(int addressId)
        {
            return new SuccessDataResult<Address>(await _addressDal.GetAsync(p => p.AddressId == addressId));
        }
        [ValidationAspect(typeof(AddressValidator))]
        public async Task<IResult> Add(Address address)
        {
          await  _addressDal.AddAsync(address);
          return new SuccessResult();
        }

        public async Task<IResult> Update(Address address)
        {
            await _addressDal.UpdateAsync(address);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Address address)
        {
            await _addressDal.DeleteAsync(address);
            return new SuccessResult();
        }

        public async Task<IResult> MultipleAddWithList(List<Address> addresses)
        {
           await _addressDal.MultipleAddAsyncWithList(addresses);
           return new SuccessResult();
        }

        public async Task<IResult> MultipleDeleteWithList(List<Address> addresses)
        {
            await _addressDal.MultipleDeleteAsyncWithList(addresses);
            return new SuccessResult();
        }

        public async Task<IResult> MultipleUpdateWithList(List<Address> addresses)
        {
            await _addressDal.MultipleUpdateAsyncWithList(addresses);
            return new SuccessResult();
        }


        [ValidationAspect(typeof(AddressValidator))]
        public async Task<IResult> MultipleAdd2(List<Address> addresses)
        {
            await _addressDal.MultipleAddAsyncWithList(addresses);
            return new SuccessResult();
        }
   }
}
