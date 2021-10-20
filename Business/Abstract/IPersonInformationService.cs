using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Rules;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dto;

namespace Business.Abstract
{
   public interface IPersonInformationService
    {
        Task<IDataResult<List<PersonInformation>>> GetAllAsync();
        Task<IDataResult<PersonInformation>> GetById(int personId);
        Task<IResult> AddAsync(PersonInformation person);
        Task<IResult> DeleteAsync(PersonInformation person);
        Task<IResult> UpdateAsync(PersonInformation person);
        
   


    }
}
