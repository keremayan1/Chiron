using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
   public class EfReligionDal:EfEntityRepository<Religion,SqlContext>,IReligionDal
    {
    }
}
