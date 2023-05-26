using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;

namespace Business.Concrete
{
    public class AdultChildrenManager : IAdultChildrenService
    {
        private IAdultChildrenDal _adultChildrenDal;
       
        public AdultChildrenManager(IAdultChildrenDal adultChildrenDal, IChildrenService childrenService, IPersonInformationService personInformationService, IChildrenPersonService childrenPersonService)
        {
            _adultChildrenDal = adultChildrenDal;
            
        }

        public async Task<IDataResult<List<AdultChildren>>> GetAll()
        {
            return new SuccessDataResult<List<AdultChildren>>(await _adultChildrenDal.GetAllAsync());
        }

        public async Task<IDataResult<AdultChildren>> GetById(int adultChildrenId)
        {
            return new SuccessDataResult<AdultChildren>(
                await _adultChildrenDal.GetAsync(ac => ac.Id == adultChildrenId));
        }
        public async Task<IDataResult<List<AdultChildrenDetailDto>>> GetAdultChildrenDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<AdultChildrenDetailDto>>> GetByAdultChildrenDetailId(int adultChildrenId)
        {
            throw new NotImplementedException();
        }
        [ValidationAspect(typeof(AdultChildrenDetailValidator))]
        public async Task<IResult> AddAdultChildrenDetail(AdultChildrenDetailDto adultChildrenDetailDto)
        {
            var result = BusinessRules.Run(ToUpper(adultChildrenDetailDto));
            if (result != null)
            {
                return result;
            }
            await _adultChildrenDal.MultipleAddAsyncWithList(adultChildrenDetailDto.AdultChildren);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAdultChildrenDetail(AdultChildrenDetailDto adultChildrenDetailDto)
        {
            var result = BusinessRules.Run(ToUpper(adultChildrenDetailDto));
            if (result != null)
            {
                return result;
            }
            await _adultChildrenDal.MultipleUpdateAsyncWithList(adultChildrenDetailDto.AdultChildren);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAdultChildrenDetail(AdultChildrenDetailDto adultChildrenDetailDto)
        {
            var result = BusinessRules.Run(ToUpper(adultChildrenDetailDto));
            if (result != null)
            {
                return result;
            }
            await _adultChildrenDal.MultipleDeleteAsyncWithList(adultChildrenDetailDto.AdultChildren);
            return new SuccessResult();
        }

        public async Task<IResult> MultipleAddAdultChildrenList(List<AdultChildrenDetailDto> adultChildrenDetailDto)
        {
            foreach (var childrenDetailDto in adultChildrenDetailDto)
            {
                var result = BusinessRules.Run(ToUpper(childrenDetailDto));
                if (result != null)
                {
                    return result;
                }
                await _adultChildrenDal.MultipleAddAsyncWithList(childrenDetailDto.AdultChildren);

            }
            return new SuccessResult();
        }


        public IResult ToUpper(AdultChildrenDetailDto adultChildrenDetailDto)
        {
            foreach (var adultChild in adultChildrenDetailDto.AdultChildren)
            {
                adultChild.FirstName = adultChild.FirstName.ToUpper();
                adultChild.LastName = adultChild.LastName.ToUpper();
            }

            return new SuccessResult();

        }

    }
}
