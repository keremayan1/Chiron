using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Entities.Concrete;
using Entities.Concrete.Dto;
using Entities.Concrete.Dto.SelectProcess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
    public class EfAdultDal : EfEntityRepository<Adult, SqlContext>, IAdultDal
    {
        private SqlContext context = new SqlContext();
        public async Task<List<AdultDetailWithRead>> GetAdultsDetail(Expression<Func<AdultDetailWithRead, bool>> filter = null)
        {
            var result = from adult in context.Adults
                         join contactInformation in context.ContactInformations on adult.Id equals contactInformation.Id
                         join personGender in context.PersonGenders on contactInformation.PersonGenderId equals personGender.Id
                         join person in context.Persons on personGender.PersonId equals person.PersonId
                         join gender in context.Genders on personGender.GenderId equals gender.GenderId
                         join marriedStatus in context.MarriedStatus on adult.MarriedStatusId equals marriedStatus.Id
                         join religion in context.Religions on adult.ReligionId equals religion.Id
                         join educationStatus in context.EducationStatus on adult.EducationStatusId equals educationStatus.Id
                         where adult.IsActive==true
                         select new AdultDetailWithRead
                         {
                             Id = adult.Id,
                             NationalId = adult.NationalId,
                             FirstName = adult.FirstName,
                             LastName = adult.LastName,
                             JobName = adult.JobName,
                             DateOfBirth = adult.DateOfBirth,
                             EthnicName = adult.EthnicName,
                             HerHasJob = adult.HerHasJob,
                             EducationStatusId = adult.EducationStatusId,
                             WhereIsLiveCountry = adult.WhereIsLiveCountry,
                             PersonName = person.PersonName,
                             GenderName = gender.GenderName,
                             MarriedStatusName = marriedStatus.Name,
                             ReligionName = religion.ReligionName,
                             EducationStatusName = educationStatus.Name,
                             ReasonOfApplication = adult.ReasonOfApplication,
                             WhereIsLiveHerHasDoes = adult.WhereIsLiveHerHasDoes,
                             WhoDidSheHeComeWith = adult.WhoDidSheHeComeWith,

                             AdultWife = (from adultWife in context.AdultWifes
                                          join wifePersonGender in context.PersonGenders on adultWife.PersonGenderId equals wifePersonGender.Id
                                          join wifePerson in context.Persons on wifePersonGender.PersonId equals wifePerson.PersonId
                                          join wifeGender in context.Genders on wifePersonGender.GenderId equals wifeGender.GenderId
                                          where adultWife.WifeId == adult.Id
                                          select adultWife.Id + " " + adultWife.FirstName + " " + wifePerson.PersonName + " " + wifeGender.GenderName).FirstOrDefault(),

                             Telephones = (from telephone in context.Telephones
                                           where adult.Id == telephone.PersonInformationId
                                           select telephone.TelephoneNumber).ToList(),
                             
                             Addresses = (from address in context.Addresses
                                          where adult.Id == address.PersonInformationId
                                          select address.AddressName).ToList(),

                             AdultChildren = (from adultChildren in context.AdultChildrens
                                              join adultAdultChildrens in context.AdultAdultChildrens on adultChildren.Id equals adultAdultChildrens.AdultChildrenId
                                              join personGenders in context.PersonGenders on adultChildren.PersonGenderId equals personGenders.Id
                                              join persons in context.Persons on personGenders.PersonId equals persons.PersonId
                                              join genders in context.Genders on personGenders.GenderId equals genders.GenderId
                                              where adult.Id == adultAdultChildrens.AdultId
                                              select adultChildren.Id + " " + adultChildren.FirstName + " " + adultChildren.LastName + " " + adultChildren.DateOfBirth + " " + genders.GenderName + " " + persons.PersonName + " " + adultChildren.HowManyChildrens + " " + adultChildren.HowManyChildrens).ToList(),

                         };

            return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();

        }
    }
}
