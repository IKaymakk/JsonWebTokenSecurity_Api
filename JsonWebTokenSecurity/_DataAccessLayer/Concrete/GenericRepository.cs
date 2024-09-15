using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using JsonWebTokenSecurity._DataAccessLayer.Abstract;
using JsonWebTokenSecurity._DataAccessLayer.Context;

namespace JsonWebTokenSecurity._DataAccessLayer.Concrete;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    SQLContext _context = new SQLContext();


  

    public async Task<int> CountFilterAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().CountAsync(filter);
    }

    public async Task CreateAsync(T t)
    {
        await _context.Set<T>().AddAsync(t);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T t)
    {
        _context.Set<T>().Remove(t);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetFilterAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().Where(filter).FirstOrDefaultAsync();
    }

    public async Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().Where(filter).ToListAsync();
    }

    public async Task UpdateAsync(T t)
    {
        _context.Set<T>().Update(t);
        await _context.SaveChangesAsync();
    }
}
