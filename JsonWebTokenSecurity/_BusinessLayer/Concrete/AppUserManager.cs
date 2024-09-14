using System.Linq.Expressions;
using Web_UI._BusinessLayer.Abstract;
using Web_UI._DataAccessLayer.Abstract;
using Web_UI._EntityLayer.Concrete;

namespace Web_UI._BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserRepository _repository;

        public AppUserManager(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(AppUser t)
        {
            var value = await _repository.GetFilterAsync(x=>x.AppUserId == t.AppUserId);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<AppUser>> GetAllAsyncFilter(Expression<Func<AppUser, bool>> filter)
        {
            return await _repository.GetAllFilterAsync(filter);
        }

        public async Task<AppUser> GetAsync(Expression<Func<AppUser, bool>> filter)
        {
            return await _repository.GetFilterAsync(filter);
        }

        public async Task InsertAsync(AppUser t)
        {
            await _repository.CreateAsync(t);
        }

        public async Task UpdateAsync(AppUser t)
        {
            await _repository.UpdateAsync(t);
        }
    }
}
