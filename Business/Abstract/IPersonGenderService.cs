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
  public  interface IPersonGenderService
    {
        Task<IDataResult<List<PersonGender>>> GetAll();
        Task<IDataResult<List<PersonGender>>> GetByGenderId(int genderId);
        Task<IDataResult<List<PersonGender>>> GetByPersonId(int personId);
        Task<IDataResult<List<PersonGender>>> GetById(int id);
       
        Task<IDataResult<List<PersonGender>>> GetByPersonIdAndGenderId(int personId,int genderId);
        Task<IResult> Add(PersonGender personGender);
        Task<IResult> Delete(PersonGender personGender);
        Task<IResult> Update(PersonGender personGender);

        //Person Detail
        IDataResult<List<PersonGenderDetail>> GetByPersonGenderDetails();


    }
}
