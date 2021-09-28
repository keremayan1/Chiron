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
   public class EfChildrenPersonDal:EfEntityRepository<ChildrenPerson,SqlContext>,IChildrenPersonDal
   {
       private SqlContext context = new SqlContext();
        public async Task<List<ChildrenPersonDetail>> GetChildrenPersonDetails(Expression<Func<ChildrenPersonDetail, bool>> filter = null)
        {
            var result = from childrenPerson in context.ChildrenPersons
                         join children in context.Childrens on childrenPerson.ChildrenId equals children.Id
                         join personInformation in context.PersonInformations on childrenPerson.Id equals
                             personInformation.Id
                         join personGender in context.PersonGenders on childrenPerson.PersonGenderId equals personGender.Id
                         join gender in context.Genders on personGender.GenderId equals gender.GenderId
                         join person in context.Persons on personGender.PersonId equals person.PersonId
                         join familyStatus in context.FamilyStatus on childrenPerson.FamilyStatusId equals familyStatus.Id
                         join educationStatus in context.EducationStatus on childrenPerson.EducationStatusId equals
                             educationStatus.Id
                         join jobs in context.Jobs on childrenPerson.JobsId equals jobs.Id
                         join address in context.Addresses on childrenPerson.Id equals address.PersonInformationId
                         join telephone in context.Telephones on childrenPerson.Id equals telephone.PersonInformationId 
                         select new ChildrenPersonDetail
                         {
                             Id = childrenPerson.Id,
                             ChildrenId = children.Id,
                             NationalId = personInformation.NationalId,
                             FirstName = personInformation.FirstName,
                             LastName = personInformation.FirstName,
                             PersonName = person.PersonName,
                             GenderName = gender.GenderName,
                             DateOfBirth = personInformation.DateOfBirth,
                             EducationStausName = educationStatus.Name,
                             FamilyName = familyStatus.Name,
                             JobName = jobs.Name,
                             AddressName = address.AddressName,
                             TelephoneNumber = telephone.TelephoneNumber

                         };
            return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();


        }
    }
}
