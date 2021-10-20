using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dto;

namespace Business.Abstract
{
  public  interface IAddressService
    {
        Task<IDataResult<List<Address>>> GetAll();
       Task< IDataResult<Address>> GetById(int addressId);
        Task<IResult> Add(Address address);
        Task<IResult> Update(Address address);
        Task<IResult> Delete(Address address);
      
        Task<IResult> MultipleAddWithList(List<Address> addresses);
        Task<IResult> MultipleDeleteWithList(List<Address> childrenPersonDetails);
        Task<IResult> MultipleUpdateWithList(List<Address> childrenPersonDetails);

    }
}
