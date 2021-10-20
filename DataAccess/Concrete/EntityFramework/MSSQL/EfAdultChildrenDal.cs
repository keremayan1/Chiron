using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Entities.Concrete;
using Entities.Concrete.Dto.SelectProcess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
   public class EfAdultChildrenDal:EfEntityRepository<AdultChildren,SqlContext>,IAdultChildrenDal
   {
       private SqlContext context = new SqlContext(); //SQL Kodu Yarin Bakilacak....
        public async Task<List<GetAdultChildrenDto>> GetAdultChildrenDetail(Expression<Func<GetAdultChildrenDto, bool>> filter = null)
        {
            var result = from adultChildren in context.AdultChildrens
                join children in context.Childrens on adultChildren.Id equals children.Id
                join childrenPerson in context.ChildrenPersons on children.Id equals childrenPerson.ChildrenId
                join personGender in context.PersonGenders on children.PersonGenderId equals personGender.Id
                join gender in context.Genders on personGender.GenderId equals gender.GenderId
                join person in context.Persons on personGender.PersonId equals person.PersonId
                join familyStatus in context.FamilyStatus on childrenPerson.FamilyStatusId equals familyStatus.Id
                select new GetAdultChildrenDto
                {
                    Id = adultChildren.Id,
                    NationalId = children.NationalId,
                    FirstName = children.FirstName,
                    LastName = children.LastName,
                    PersonName = person.PersonName,
                    GenderName = gender.GenderName,
                    DateOfBirth = children.DateOfBirth,
                    ClassName = children.ClassName,
                    SchoolName = children.SchoolName,
                    FamilyStatusName = familyStatus.Name
                };
            return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();
        }
    }
}
