using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
   public interface IAsyncEntityRepository<T> where T:class,IEntity,new()
   {
       Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
       Task<T> GetAsync(Expression<Func<T, bool>> filter);
       Task AddAsync(T entity);
       Task DeleteAsync(T entity);
       Task UpdateAsync(T entity);
       Task MultipleAddAsync(T[] entities);
       Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
       Task MultipleAddAsyncWithList(List<T> entities);
       Task MultipleUpdateAsyncWithList(List<T> entities);
       Task MultipleDeleteAsyncWithList(List<T> entities);

    }
}
