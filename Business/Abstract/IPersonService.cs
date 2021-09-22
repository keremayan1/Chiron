using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IPersonService
   {
       Task<IDataResult<List<Person>>> GetAllAsync();
       Task<IDataResult<Person>> GetById(int personId);
       Task<IResult> AddAsync(Person person);
       Task<IResult> DeleteAsync(Person person);
       Task<IResult> UpdateAsync(Person person);
       Task<IDataResult<List<Person>>> GetByName(string name);


   }
}
