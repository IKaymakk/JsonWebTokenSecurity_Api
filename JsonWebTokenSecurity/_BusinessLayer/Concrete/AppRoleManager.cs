using System.Linq.Expressions;
using JsonWebTokenSecurity._BusinessLayer.Abstract;
using JsonWebTokenSecurity._DataAccessLayer.Abstract;
using JsonWebTokenSecurity._EntityLayer.Concrete;

namespace JsonWebTokenSecurity._BusinessLayer.Concrete
{
    public class AppRoleManager : IAppRoleService
    {
        IAppRoleRepository _repository;

        public AppRoleManager(IAppRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(AppRole t)
        {
            var value = await _repository.GetFilterAsync(x => x.AppRoleId == t.AppRoleId);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<AppRole>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<AppRole>> GetAllAsyncFilter(Expression<Func<AppRole, bool>> filter)
        {
            return await _repository.GetAllFilterAsync(filter);
        }

        public async Task<AppRole> GetAsync(Expression<Func<AppRole, bool>> filter)
        {
            return await _repository.GetFilterAsync(filter);
        }

        public async Task InsertAsync(AppRole t)
        {
            await _repository.CreateAsync(t);
        }

        public async Task UpdateAsync(AppRole t)
        {
            await _repository.UpdateAsync(t);
        }
    }
}
