using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
  public  interface IAddressService
    {
        Task<IDataResult<List<Address>>> GetAll();
        IDataResult<Address> GetById(int addressId);
        Task<IResult> Add(Address address);
        Task<IResult> Update(Address address);
        Task<IResult> Delete(Address address);
    }
}
