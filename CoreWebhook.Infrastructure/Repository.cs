using CoreWebhook.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace CoreWebhook.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        internal DbSet<T> _entities;
        protected readonly ILogger _logger;
        public Repository(DbContext context,ILogger logger) 
        {
            _context = context;
            _entities= _context.Set<T>();
            _logger = logger;
        }

        public virtual async Task<int> Add(T entity)
        {
           var tentity=await _entities.AddAsync(entity);
            return 1;
        }

        public virtual async Task<bool> AddRange(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
            return true;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
