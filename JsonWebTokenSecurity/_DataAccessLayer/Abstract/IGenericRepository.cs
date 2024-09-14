using System.Linq.Expressions;

namespace Web_UI._DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T t);
        Task DeleteAsync(T t);
        Task UpdateAsync(T t);
        Task<T> GetFilterAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> filter);
        Task<int> CountFilterAsync(Expression<Func<T, bool>> filter);
    }
}
