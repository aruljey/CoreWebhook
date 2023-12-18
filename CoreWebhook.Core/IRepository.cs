using System.Linq.Expressions;

namespace CoreWebhook.Core
{
    public interface IRepository<T> where T : class
    {
        #region Select/Get/Query
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<bool> AddRange(IEnumerable<T> entities);
        Task<bool> Delete(int id);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        #endregion
    }
}