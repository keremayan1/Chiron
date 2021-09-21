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
    public class EfPersonGenderDal : EfEntityRepository<PersonGender, SqlContext>, IPersonGenderDal
    {
        private SqlContext context = new SqlContext();
        public async Task<List<PersonGenderDetail>> GetPersonInformationDetail(Expression<Func<PersonGenderDetail, bool>> filter = null)
        {
            var result = 
                from personGender in context.PersonGenders
                join gender in context.Genders on personGender.GenderId equals gender.GenderId
                join person in context.Persons on personGender.PersonId equals person.PersonId 

                  where personGender.GenderId == gender.GenderId && personGender.PersonId == person.PersonId
                         select new PersonGenderDetail
                         {
                             Id = personGender.Id,
                             PersonName = person.PersonName,
                           GenderName = gender.GenderName
                         };
            return filter == null ?
                await result.ToListAsync() : 
                await result.Where(filter).ToListAsync();
        }
    }
}
