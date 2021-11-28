using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Rules;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;
using Entities.Concrete.Dto.SelectProcess;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class ChildrenManager : IChildrenService
    {
        private IChildrenDal _childrenDal;
        private IPersonService _personService;
        private ITelephoneService _telephoneService;
        private IChildrenPersonService _childrenPersonService;
        private IContactInformationService _contactInformationService;
        private IChildrenSiblingsService _childrenSiblingsService;

        public ChildrenManager(IChildrenDal childrenDal, ITelephoneService telephoneService, IChildrenPersonService childrenPersonService, IContactInformationService contactInformationService, IPersonService personService, IChildrenSiblingsService childrenSiblingsService)
        {
            _childrenDal = childrenDal;
            _telephoneService = telephoneService;
            _childrenPersonService = childrenPersonService;
            _contactInformationService = contactInformationService;
            _personService = personService;
            _childrenSiblingsService = childrenSiblingsService;
        }

        public async Task<IDataResult<List<Children>>> GetAll()
        {
            return new SuccessDataResult<List<Children>>(await _childrenDal.GetAllAsync());
        }

        public IDataResult<Children> GetById(int childrenId)
        {
            return new SuccessDataResult<Children>(_childrenDal.GetAsync(c => c.Id == childrenId).Result);
        }
        public async Task<IResult> MultipleAdd(List<Children> childrens)
        {
            await _childrenDal.MultipleAddAsyncWithList(childrens);
            return new SuccessResult();
        }

        
        // [ValidationAspect(typeof(ChildrenDetailValidator))]
        public async Task<IResult> MultipleChildrenDetailAdd(ChildrenDetail children)
        {

            //var result = BusinessRules.Run(CheckIfNationalIdExists(children.Children.NationalId), CheckTelephoneListNumberExists(children.Telephones));
            //if (result != null)
            //{
            //    return result;
            //}

            await _childrenDal.AddAsync(children.Children);
            MultipleProcessInChildrenPerson(children);
            await _childrenPersonService.MultipleAddWithList(children.ChildrenPersonDetail);
            MultipleProcessInTelephonesOnChildren(children);
            await _telephoneService.MultipleAddWithList(children.Telephones);
            
            await HaveChildrenSiblings(children);
            return new SuccessResult("Basarili");
        }

        private async Task HaveChildrenSiblings(ChildrenDetail children)
        {
            if (children.DoedHaveChildrenSiblings)
            {
                GetChildrenSiblings(children);
                await _childrenSiblingsService.MultipleAddWithList(children.ChildrenSiblings);
            }
            
        }

        private static void GetChildrenSiblings(ChildrenDetail children)
        {
            foreach (var childrenSibling in children.ChildrenSiblings)
            {
                childrenSibling.ChildrenId = children.Children.Id;
            }
        }

        [ValidationAspect(typeof(ChildrenDetailValidator))]
        public async Task<IResult> MultipleChildrenDetailUpdate(ChildrenDetail children)
        {
            var result = BusinessRules.Run(CheckIfNationalIdExists(children.Children.NationalId));
            if (result != null)
            {
                return result;
            }
            await _childrenDal.UpdateAsync(children.Children);
            MultipleProcessInChildrenPerson(children);
            await _childrenPersonService.MultipleUpdateWithList(children.ChildrenPersonDetail);
            MultipleProcessInTelephonesOnChildren(children);
            await _telephoneService.MultipleUpdateWithList(children.Telephones);
            await _childrenSiblingsService.MultipleDeleteWithList(children.ChildrenSiblings);
            return new SuccessResult("Basarili");
        }

        public async Task<IResult> MultipleChildrenDetailDelete(ChildrenDetail children)
        {
            var result = BusinessRules.Run(VerifyNationalId(children.Children), CheckIfNationalIdExists(children.Children.NationalId));
            if (result != null)
            {
                return result;
            }
            await _childrenDal.DeleteAsync(children.Children);
            MultipleProcessInChildrenPerson(children);
            await _childrenPersonService.MultipleDeleteWithList(children.ChildrenPersonDetail);
            MultipleProcessInTelephonesOnChildren(children);
            await _telephoneService.MultipleUpdateWithList(children.Telephones);
            return new SuccessResult("Basarili");
        }

        private static void MultipleProcessInChildrenPerson(ChildrenDetail childrenDetail)
        {
            foreach (var c in childrenDetail.ChildrenPersonDetail)
            {
                c.ChildrenPerson.ChildrenId = childrenDetail.Children.Id;
            }
        }

        private static void MultipleProcessInTelephonesOnChildren(ChildrenDetail childrenDetail)
        {
            foreach (var telephone in childrenDetail.Telephones)
            {
                telephone.PersonInformationId = childrenDetail.Children.Id;
            }
        }



    

        public async Task<IResult> Add(Children children)
        {
            var result = BusinessRules.Run(VerifyNationalId(children), CheckIfNationalIdExists(children.NationalId));
            if (result != null)
            {
                return result;
            }
            await _childrenDal.AddAsync(children);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Children children)
        {
            var result = BusinessRules.Run(IsPersonAvaliable(children.Id));
            if (result != null)
            {
                return result;
            }
            await _childrenDal.DeleteAsync(children);
            return new SuccessResult();
        }

        public async Task<IResult> Update(Children children)
        {
            var result = BusinessRules.Run(CheckIfNationalIdExists(children.NationalId));
            if (result != null)
            {
                return result;
            }
            await _childrenDal.UpdateAsync(children);
            return new SuccessResult();
        }
        public IResult IsPersonAvaliable(int personId)
        {
            var result = _personService.GetById(personId).Result;
            if (result != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
        public IResult ToUpper(Children children)
        {
            children.FirstName = children.FirstName.ToUpper();
            children.LastName = children.LastName.ToUpper();
            children.SchoolName = children.SchoolName.ToUpper();
            return new SuccessResult();

        }

        public IResult CheckIfNationalIdExists(string nationalId)
        {
            var result = _contactInformationService.CheckIfNationalIdExists(nationalId);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccessResult();

        }

        public IResult VerifyNationalId(Children personInformation)
        {
            var result = _contactInformationService.VerifyNationalId(personInformation);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccessResult();
        }

        public IResult CheckTelephoneNumberExists(string telephoneNumber)
        {
            var result = _telephoneService.CheckTelephoneNumberExists(telephoneNumber);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccessResult();
        }

        public IResult CheckTelephoneListNumberExists(List<Telephone> telephones)
        {
            var result = _telephoneService.CheckTelephoneListNumberExists(telephones);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            return new SuccessResult();
        }
        private IResult ChildPersonCheckTelephoneNumberExists(string telephoneNumber)
        {
            var result = _childrenPersonService.CheckTelephoneNumberExists(telephoneNumber);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            return new SuccessResult();
        }
        public async Task<IDataResult<List<ChildrenDetailDtoJustRead>>> GetChildrenDetails()
        {
            return new SuccessDataResult<List<ChildrenDetailDtoJustRead>>(await _childrenDal.GetChildrenDetails());
        }
    }
}
