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
   public interface IAdultChildrenService
    {
        Task<IDataResult<List<AdultChildren>>> GetAll();
        Task<IDataResult<AdultChildren>> GetById(int adultChildrenId);
      

        //AdultChildrenDetailDto
        Task<IDataResult<List<AdultChildrenDetailDto>>> GetAdultChildrenDetails();
        Task<IDataResult<List<AdultChildrenDetailDto>>> GetByAdultChildrenDetailId(int adultChildrenId);
        Task<IResult> AddAdultChildrenDetail(AdultChildrenDetailDto adultChildrenDetailDto);
        Task<IResult> UpdateAdultChildrenDetail(AdultChildrenDetailDto adultChildrenDetailDto);
        Task<IResult> DeleteAdultChildrenDetail(AdultChildrenDetailDto adultChildrenDetailDto);
        Task<IResult> MultipleAddAdultChildrenList(List<AdultChildrenDetailDto> adultChildrenDetailDto);
    }
}
