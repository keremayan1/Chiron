using DataAccess.Concrete.EntityFramework.MSSQL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class DBTool
    {
        private DBTool() { }

        static SqlContext _dbInstance;

        public static SqlContext DBInstance
        {
            get
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new SqlContext();
                }
                return _dbInstance;
            }
        }
    }
}
