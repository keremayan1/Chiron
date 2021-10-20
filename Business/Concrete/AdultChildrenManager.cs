using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
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
        private IChildrenService _childrenService;
        private IPersonInformationService _personInformationService;
        private IChildrenPersonService _childrenPersonService;
        public AdultChildrenManager(IAdultChildrenDal adultChildrenDal, IChildrenService childrenService, IPersonInformationService personInformationService, IChildrenPersonService childrenPersonService)
        {
            _adultChildrenDal = adultChildrenDal;
            _childrenService = childrenService;
            _personInformationService = personInformationService;
            _childrenPersonService = childrenPersonService;
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

        public async Task<IResult> AddAdultChildrenDetail(AdultChildrenDetailDto adultChildrenDetailDto)
        {
            var result = BusinessRules.Run(ToUpper(adultChildrenDetailDto));
            if (result!=null)
            {
                return result;
            }
            await _childrenService.MultipleAdd(adultChildrenDetailDto.Childrens);
           GetByChildrenIdToAdultChildrenId(adultChildrenDetailDto);
            await _adultChildrenDal.AddAsync(adultChildrenDetailDto.AdultChildren);
           return new SuccessResult();

        }

        public async Task<IResult> UpdateAdultChildrenDetail(AdultChildrenDetailDto adultChildrenDetailDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> DeleteAdultChildrenDetail(AdultChildrenDetailDto adultChildrenDetailDto)
        {
            throw new NotImplementedException();
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
                await _childrenService.MultipleAdd(childrenDetailDto.Childrens);
                GetByChildrenIdToAdultChildrenId(childrenDetailDto);
                await _adultChildrenDal.AddAsync(childrenDetailDto.AdultChildren);
               
            }
            return new SuccessResult();
        }

        private static void GetByChildrenIdToAdultChildrenId(AdultChildrenDetailDto childrenDetailDto)
        {
            foreach (var children in childrenDetailDto.Childrens)
            {
                childrenDetailDto.AdultChildren.Id = children.Id;
            }
        }
        public IResult ToUpper(AdultChildrenDetailDto adultChildrenDetailDto)
        {
            foreach (var children in adultChildrenDetailDto.Childrens)
            {
                children.FirstName = children.FirstName.ToUpper();
                children.LastName = children.LastName.ToUpper();
            }
            
            return new SuccessResult();

        }

    }
}
