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
    public class EfPersonInformationDal : EfEntityRepository<PersonInformation, SqlContext>, IPersonInformationDal
    {
        private SqlContext context = new SqlContext();
        public async Task<List<PersonInformationDetail>> GetPersonInformationDetail(Expression<Func<PersonInformationDetail, bool>> filter = null)
        {
            var result = from person in context.Persons
                         join personInformation in context.PersonInformations on person.PersonId equals personInformation
                             .PersonId
                         where person.PersonId == personInformation.PersonId
                         select new PersonInformationDetail
                         {
                             Id = personInformation.PersonId,
                             PersonName = person.PersonName,
                             NationalId = personInformation.NationalId,
                             FirstName = personInformation.FirstName,
                             LastName = personInformation.LastName,
                             DateOfBirth = personInformation.DateOfBirth,
                         };
            return filter == null
                ? await result.ToListAsync()
                : await result.Where(filter).ToListAsync();

        }
    }
}
