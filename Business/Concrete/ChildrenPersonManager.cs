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
    public class ChildrenPersonManager : IChildrenPersonService
    {
        private IChildrenPersonDal _childrenPersonDal;
        private IChildrenService _childrenService;

        public ChildrenPersonManager(IChildrenPersonDal childrenPersonDal, IChildrenService childrenService)
        {
            _childrenPersonDal = childrenPersonDal;
            _childrenService = childrenService;
        }


        public async Task<IDataResult<List<ChildrenPerson>>> GetAll()
        {
            return new SuccessDataResult<List<ChildrenPerson>>(await _childrenPersonDal.GetAllAsync());
        }

        public async Task<IDataResult<ChildrenPerson>> GetById(int childrenPersonId)
        {
            return new SuccessDataResult<ChildrenPerson>(
                await _childrenPersonDal.GetAsync(ch => ch.Id == childrenPersonId));
        }

        public async Task<IResult> Add(ChildrenPerson childrenPerson)
        {
            var childrenDetail = new ChildrenDetail
            {

            };
            await _childrenService.Add(childrenDetail);
            childrenPerson.ChildrenId = childrenDetail.Id;
            await _childrenPersonDal.AddAsync(childrenPerson);

            return new SuccessResult();
        }

        public async Task<IResult> Update(ChildrenPerson childrenPerson)
        {
            await _childrenPersonDal.UpdateAsync(childrenPerson);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(ChildrenPerson childrenPerson)
        {
            await _childrenPersonDal.DeleteAsync(childrenPerson);
            return new SuccessResult();
        }

        public async Task<IResult> AddAsync(ChildrenPersonDetail childrenPersonDetail)
        {
            var childrenDetail = new ChildrenDetail
            {

                
                PersonName = childrenPersonDetail.PersonName,
                NationalId = childrenPersonDetail.NationalId,
                FirstName = childrenPersonDetail.FirstName,
                LastName = childrenPersonDetail.LastName,
                GenderName = childrenPersonDetail.GenderName,
                DateOfBirth = childrenPersonDetail.DateOfBirth, 
            };
            await _childrenService.Add(childrenDetail);
            var childrenPerson = new ChildrenPerson
            {
                ChildrenId = childrenPersonDetail.ChildrenId,
                PersonInformationId = childrenPersonDetail.PersonInformationId,
                PersonGenderId = childrenPersonDetail.PersonGenderId,
                EducationStatusId = childrenPersonDetail.EducationStatusId,
                FamilyStatusId = childrenPersonDetail.FamilyStatusId,
                JobsId = childrenPersonDetail.JobsId,
            };

            await _childrenPersonDal.AddAsync(childrenPerson);
            return new SuccessResult("Basarili");
        }

        public async Task<IDataResult<List<ChildrenPersonDetail>>> GetChildrenPersonDetails()
        {
            return new SuccessDataResult<List<ChildrenPersonDetail>>(
                await _childrenPersonDal.GetChildrenPersonDetails());
        }

        List<ChildrenPerson> childrenPersons = new List<ChildrenPerson>();
        public async Task<IResult> MultipleAdd(ChildrenPersonDetail childrenPersonDetail)
        {

            foreach (var childrenPersonLoop in childrenPersons)
            {
                ChildrenPerson(childrenPersonDetail, out var childrenPerson);
                var childrenDetail = ChildrenDetail(childrenPersonDetail);
                await _childrenService.Add(childrenDetail);
            }
            await _childrenPersonDal.MultipleAddAsync(childrenPersons.ToArray());
            return new SuccessResult();
        }

        public async Task<IResult> AddAsync2(ChildrenPerson childrenPersonDetail)
        {
            return new SuccessResult();

        }

        private static void ChildrenPerson(ChildrenPersonDetail childrenPersonDetail, out ChildrenPerson childrenPerson)
        {
            childrenPerson = new ChildrenPerson
            {
                ChildrenId = childrenPersonDetail.ChildrenId,
                PersonGenderId = childrenPersonDetail.PersonGenderId,
                PersonInformationId = childrenPersonDetail.PersonInformationId,
                EducationStatusId = childrenPersonDetail.EducationStatusId,
                FamilyStatusId = childrenPersonDetail.FamilyStatusId,
                JobsId = childrenPersonDetail.JobsId
            };
        }

        private static ChildrenDetail ChildrenDetail(ChildrenPersonDetail childrenPersonDetail)
        {
            var childrenDetail = new ChildrenDetail
            {
                PersonGenderId = childrenPersonDetail.PersonGenderId,
                PersonInformationId = childrenPersonDetail.PersonInformationId,
                NationalId = childrenPersonDetail.NationalId,
                FirstName = childrenPersonDetail.FirstName,
                LastName = childrenPersonDetail.LastName,
                GenderName = childrenPersonDetail.GenderName,
                DateOfBirth = childrenPersonDetail.DateOfBirth
            };
            return childrenDetail;
        }
    }
}
