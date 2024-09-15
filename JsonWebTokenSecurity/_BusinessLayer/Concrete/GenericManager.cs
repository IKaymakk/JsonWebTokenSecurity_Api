using System.Linq.Expressions;
using JsonWebTokenSecurity._BusinessLayer.Abstract;
using JsonWebTokenSecurity._DataAccessLayer.Abstract;

namespace JsonWebTokenSecurity._BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericManager(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(T t)
        {
            await _repository.DeleteAsync(t);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _repository.GetFilterAsync(filter);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<T>> GetAllAsyncFilter(Expression<Func<T, bool>> filter)
        {
            return await _repository.GetAllFilterAsync(filter);
        }

        public async Task InsertAsync(T t)
        {
            await _repository.CreateAsync(t);
        }

        public async Task UpdateAsync(T t)
        {
            await _repository.UpdateAsync(t);
        }
    }
}
