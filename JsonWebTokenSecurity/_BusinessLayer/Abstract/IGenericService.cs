using System.Linq.Expressions;

namespace JsonWebTokenSecurity._BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task InsertAsync(T t);
        Task DeleteAsync(T t);
        Task UpdateAsync(T t);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsyncFilter(Expression<Func<T, bool>> filter);

    }
}
