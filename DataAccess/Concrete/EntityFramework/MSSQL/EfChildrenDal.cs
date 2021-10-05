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
            
            var result = from children in context.Childrens
                         join personInformation in context.PersonInformations on children.Id equals
                             personInformation.Id
                         join personGender in context.PersonGenders on personInformation.PersonGenderId equals personGender.Id
                         join gender in context.Genders on personGender.GenderId equals gender.GenderId
                         join person in context.Persons on personGender.PersonId equals person.PersonId
                         join telephone in context.Telephones on personInformation.Id equals telephone.PersonInformationId 

                         select new ChildrenDetail
                         {
                          Children = new Children
                          {
                              FirstName = children.FirstName,
                              LastName = children.LastName,
                          }, Telephone = new Telephone
                          {
                              TelephoneNumber = telephone.TelephoneNumber
                          },
                        
                          
                        
                         
                       

                         };

            return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();

        }
    }
}
