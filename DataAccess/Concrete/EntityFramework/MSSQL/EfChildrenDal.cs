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
using Entities.Concrete.Dto.SelectProcess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
    public class EfChildrenDal : EfEntityRepository<Children, SqlContext>, IChildrenDal
    {
        private SqlContext context = new SqlContext();
        public async Task<List<ChildrenDetailDtoJustRead>> GetChildrenDetails(Expression<Func<ChildrenDetailDtoJustRead, bool>> filter = null)
        {

            var result = from children in context.Childrens
                         join contactInformation in context.ContactInformations on children.Id equals
                             contactInformation.Id
                         join personGender in context.PersonGenders on children.PersonGenderId equals personGender.Id
                         join gender in context.Genders on personGender.GenderId equals gender.GenderId
                         join person in context.Persons on personGender.PersonId equals person.PersonId


                         select new ChildrenDetailDtoJustRead
                         {
                             Id = children.Id,
                             NationalId = contactInformation.NationalId,
                             FirstName = contactInformation.FirstName,
                             LastName = contactInformation.LastName,
                             PersonName = person.PersonName,
                             GenderName = gender.GenderName,
                             SchoolName = children.SchoolName,
                             ClassName = children.ClassName,
                             DateOfBirth = children.DateOfBirth,
                             TelephoneNumber = (from telephone in context.Telephones
                                                where children.Id == telephone.PersonInformationId 
                                                select telephone.TelephoneNumber).ToList(),

                             ChildPerson = (from childPerson in context.ChildrenPersons
                                            join personInformation in context.PersonInformations on childPerson.Id equals personInformation.Id
                                            join personGender in context.PersonGenders on childPerson.PersonGenderId equals personGender.Id
                                            join childrenPerson in context.Persons on personGender.PersonId equals childrenPerson.PersonId
                                            join childrenGender in context.Genders on personGender.GenderId equals childrenGender.GenderId
                                            join familyStatus in context.FamilyStatus on childPerson.FamilyStatusId equals familyStatus.Id
                                            join educationStatus in context.EducationStatus on childPerson.EducationStatusId equals educationStatus.Id

                                            where childPerson.ChildrenId == children.Id

                                            select childPerson.Id + " " +
                                            childPerson.FirstName + " " +
                                            childPerson.LastName + " " +
                                            childPerson.DateOfBirth + " " +
                                            childrenPerson.PersonName + " " +
                                            childrenGender.GenderName + " " +
                                            childPerson.JobName + " " +
                                            familyStatus.Name + " " +
                                            educationStatus.Name).ToList(),
                             ChildPersonTelephones=(from childPersonTelephones in context.ChildrenPersons
                                                    join telephones in context.Telephones on childPersonTelephones.Id equals telephones.PersonInformationId
                                                    where childPersonTelephones.ChildrenId == children.Id
                                                    select  childPersonTelephones.Id +" "+telephones.TelephoneNumber).ToList(),
                           
                             ChildPersonAddresses = (from childPersonAddresses in context.ChildrenPersons
                                                     join addresses in context.Addresses on childPersonAddresses.Id equals addresses.PersonInformationId
                                                     where childPersonAddresses.ChildrenId == children.Id
                                                     select childPersonAddresses.Id+" "+ addresses.AddressName).ToList(),
                             ChildrenSiblings = (from childSiblings in context.ChildrenSiblings
                                                 join siblingPersonInformation in context.PersonInformations on childSiblings.Id equals siblingPersonInformation.Id
                                                 join siblingPersonGender in context.PersonGenders on childSiblings.PersonGenderId equals siblingPersonGender.Id
                                                 join siblingChildrenPerson in context.Persons on siblingPersonGender.PersonId equals siblingChildrenPerson.PersonId
                                                 join siblingChildrenGender in context.Genders on siblingPersonGender.GenderId equals siblingChildrenGender.GenderId
                                                 join siblingEducationStatus in context.EducationStatus on childSiblings.EducationStatusId equals siblingEducationStatus.Id

                                                 where childSiblings.ChildrenId == children.Id

                                                 select childSiblings.Id + " " + 
                                                        childSiblings.FirstName + " "+ 
                                                        childSiblings.LastName+ " "+
                                                        childSiblings.DateOfBirth + " " +
                                                        siblingChildrenPerson.PersonName + " "+
                                                        siblingChildrenGender.GenderName + " "+
                                                        childSiblings.WhichChild + " "+
                                                        siblingEducationStatus.Name).ToList()                  
                         };

            return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();

        }
    }
}
