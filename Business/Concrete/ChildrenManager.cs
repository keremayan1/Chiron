using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;

namespace Business.Concrete
{
  public  class ChildrenManager:IChildrenService
  {
      private IChildrenDal _childrenDal;
      private IPersonService _personService;
      private IPersonInformationService _personInformationService;
      private IGenderService _genderService;

      public ChildrenManager(IChildrenDal childrenDal, IPersonService personService, IPersonInformationService personInformationService, IGenderService genderService)
      {
          _childrenDal = childrenDal;
          _personService = personService;
          _personInformationService = personInformationService;
          _genderService = genderService;
      }

      public async Task<IDataResult<List<Children>>> GetAll()
      {
          return new SuccessDataResult<List<Children>>(await _childrenDal.GetAllAsync());
      }

        public async Task<IDataResult<Children>> GetById(int childrenId)
        {
            return new SuccessDataResult<Children>(await _childrenDal.GetAsync(c => c.Id == childrenId));
        }

        public async Task<IResult> Add(ChildrenDetail childrenDetail)
        {
            var personInformation = PersonInformation(childrenDetail);
            var children = Children(childrenDetail);
            await _personInformationService.AddAsync(personInformation);
            children.PersonInformationId = personInformation.Id;
            await _childrenDal.AddAsync(children);
            return new SuccessResult("Basarili");
        }

        private static Children Children(ChildrenDetail childrenDetail)
        {
            var children = new Children
            {
                SchoolName = childrenDetail.SchoolName,
                ClassName = childrenDetail.ClassName
            };
            return children;
        }

        private static PersonInformation PersonInformation(ChildrenDetail childrenDetail)
        {
            var personInformation = new PersonInformation
            {
                NationalId = childrenDetail.NationalId,
                FirstName = childrenDetail.FirstName,
                LastName = childrenDetail.LastName,
                DateOfBirth = childrenDetail.DateOfBirth,
            };
            return personInformation;
        }

        public Task<IResult> Update(ChildrenDetail childrenDetail)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(ChildrenDetail childrenDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<ChildrenDetail>>> GetChildrenDetails()
        {
            return new SuccessDataResult<List<ChildrenDetail>>(await _childrenDal.GetChildrenDetails());
        }

        public IResult IsPersonAvaliable(int personId)
        {
            var result = _personService.GetById(personId).Result;
            if (result!=null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
