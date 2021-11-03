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
                         join adultWife in context.AdultWifes on adult.Id equals adultWife.WifeId
                         join personGender in context.PersonGenders on adult.PersonGenderId equals personGender.Id
                         join gender in context.Genders on personGender.GenderId equals gender.GenderId
                         join person in context.Persons on personGender.PersonId equals person.PersonId
                         //join religion in context.Religions on adult.ReligionId equals religion.Id
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

                             //   AdultChildrenDetail = new List<AdultChildrenDetailDto>(),
                             AdultWifes = new AdultWife
                             {
                                 FirstName = adultWife.FirstName,
                                 LastName = adultWife.LastName,
                                 WifeId = adultWife.WifeId,
                                 JobName = adultWife.JobName,
                                 DateOfBirth = adultWife.DateOfBirth
                             },
                             // Adults = new Adult(),

                             //Religion = new Religion(),
                             //  ReasonOfApplication = adult.ReasonOfApplication,

                         };
            return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();




        }

        public async Task<List<AdultDetailDto>> GetAdultDetails2(Expression<Func<AdultDetailDto, bool>> filter = null)
        {
            var result = from adult in context.Adults
                         join contactInformation in context.ContactInformations on adult.Id equals contactInformation.Id
                       //  join adultWife in context.AdultWifes on adult.Id equals adultWife.WifeId
                        

                      //   where adult.Id == telephone.PersonInformationId

                         select new AdultDetailDto
                         {
                             Adults = new Adult
                             {
                                 FirstName = adult.FirstName,
                                 LastName = adult.LastName,
                                 JobName = adult.JobName,
                                 DateOfBirth = adult.DateOfBirth,
                                 EthnicName = adult.EthnicName,
                                 IsAdded = adult.IsAdded,
                                 IsActive = adult.IsActive,
                                 HerHasJob = adult.HerHasJob,
                                 NationalId = adult.NationalId,
                                 EducationStatusId = adult.EducationStatusId,
                                 WhereIsLiveCountry = adult.WhereIsLiveCountry,
                                 

                             },
                             //AdultWifes = new AdultWife
                             //{
                             //    FirstName = adultWife.FirstName,
                             //    LastName = adultWife.LastName,
                             //    WifeId = adultWife.WifeId,
                             //    JobName = adultWife.JobName,
                             //    DateOfBirth = adultWife.DateOfBirth
                             //},
                             TelephoneNumber = string.Join(',',from telephone2 in context.Telephones where adult.Id == telephone2.PersonInformationId select telephone2.TelephoneNumber + " "+ telephone2.PersonInformationId),
                             AddressName = string.Join(',', from address in context.Addresses where adult.Id==address.PersonInformationId select address.AddressName)
                             




                         };
            return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();

        }
    }
}
