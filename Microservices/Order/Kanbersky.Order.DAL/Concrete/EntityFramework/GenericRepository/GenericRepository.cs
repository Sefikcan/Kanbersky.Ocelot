using Kanbersky.Ocelot.Core.Entity;
using Kanbersky.Ocelot.Core.Extensions;
using Kanbersky.Ocelot.Core.Helpers.Pagination;
using Kanbersky.Order.DAL.Concrete.EntityFramework.Context;
using Kanbersky.Order.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kanbersky.Order.DAL.Concrete.EntityFramework.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, IEntity, new()
    {
        private readonly OrderContext _context;
        private DbSet<T> _entities;

        public GenericRepository(OrderContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ?
                await _context.Set<T>().ToListAsync() :
                await _context.Set<T>().Where(expression).ToListAsync();
        }

        public PagedResult<T> GetPaged(int? page = 1, int? pageSize = 10)
        {
            return _entities.GetPaged(page.Value, pageSize.Value);
        }

        public IQueryable<T> GetQueryable()
        {
            return _entities.AsQueryable();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                return null;
            }

            T exists = await _context.Set<T>().FindAsync(entity.Id);
            if (exists != null)
            {
                _context.Entry(exists).CurrentValues.SetValues(entity);
            }
            return exists;
        }
    }
}
