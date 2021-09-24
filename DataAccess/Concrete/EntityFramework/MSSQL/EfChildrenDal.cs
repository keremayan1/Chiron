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
using Entities.Concrete.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
   public class EfChildrenDal:EfEntityRepository<Children,SqlContext>,IChildrenDal
   {
       private SqlContext context = new SqlContext();
        public async Task<List<ChildrenDetail>> GetChildrenDetails(Expression<Func<ChildrenDetail, bool>> filter = null)
        {
            //var result = from children in context.Childrens
            //    join person in context.Persons on children.PersonId equals person.PersonId
            //    join personInformation in context.PersonInformations on children.PersonInformationId equals
            //        personInformation.Id
            //    join gender in context.Genders on children.GenderId equals gender.GenderId
            var result = from children in context.Childrens
                join personInformation in context.PersonInformations on children.PersonInformationId equals
                    personInformation.Id
                join personGender in context.PersonGenders on personInformation.PersonGenderId equals personGender.Id

                join gender in context.Genders on personGender.GenderId equals gender.GenderId
                join person in context.Persons on personGender.PersonId equals person.PersonId
                
                select new ChildrenDetail
                {
                    Id = children.Id,
                    NationalId = personInformation.NationalId,
                    PersonName = person.PersonName,
                    GenderName = gender.GenderName,
                    FirstName = personInformation.FirstName,
                    LastName = personInformation.LastName,
                    DateOfBirth = personInformation.DateOfBirth,
                    ClassName = children.ClassName,
                    SchoolName = children.SchoolName

                };
                         
            return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();

        }
    }
}
