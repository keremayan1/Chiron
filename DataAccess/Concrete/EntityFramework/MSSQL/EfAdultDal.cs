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
    public class EfAdultDal : EfEntityRepository<Adult, SqlContext>, IAdultDal
    {
        private SqlContext context = new SqlContext();
        public async Task<List<AdultDetailDto>> GetAdultDetails(Expression<Func<AdultDetailDto, bool>> filter = null)
        {
            var result = from adult in context.Adults
                join contactInformation in context.ContactInformations on adult.Id equals contactInformation.Id
                join personGender in context.PersonGenders on adult.PersonGenderId equals personGender.Id
                join gender in context.Genders on personGender.GenderId equals gender.GenderId
                join person in context.Persons on personGender.PersonId equals person.PersonId
                join religion in context.Religions on adult.ReligionId equals religion.Id
                join educationStatus in context.EducationStatus on adult.EducationStatusId equals educationStatus.Id
                join marriedStatus in context.MarriedStatus on adult.MarriedStatusId equals marriedStatus.Id
                where adult.IsActive == true
                select new AdultDetailDto
                {
                //    Adults = adult.Id,
                //    NationalId = personInformation.NationalId,
                //    FirstName = personInformation.FirstName,
                //    LastName = personInformation.LastName,
                //    DateOfBirth = personInformation.DateOfBirth,
                //    PersonName = person.PersonName,
                //    GenderName = gender.GenderName,
                //    EthnicName = adult.EthnicName,
                //    ReligionName = religion.ReligionName,
                //    EducationName = educationStatus.Name,
                //    MarriedStatusName = marriedStatus.Name,
                //    ReasonOfApplication = religion.ReligionName
                };
            return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();




        }
    }
}
