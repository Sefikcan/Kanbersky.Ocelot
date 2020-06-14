using Kanbersky.Ocelot.Core.Entity;
using Kanbersky.Ocelot.Core.Helpers.Pagination;
using Kanbersky.Order.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kanbersky.Order.DAL.Concrete.EntityFramework.GenericRepository
{
    public interface IGenericRepository<T> where T: BaseEntity, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression = null);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        void Delete(T entity);

        Task<int> SaveChangesAsync();

        PagedResult<T> GetPaged(int? page = 1, int? pageSize = 10);

        IQueryable<T> GetQueryable();
    }
}
