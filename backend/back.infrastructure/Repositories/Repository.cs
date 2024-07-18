using back.domain;
using back.domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace back.infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly MyDbContext _cx;

    public Repository(MyDbContext cx)
    {
        _cx = cx;
    }

    public async Task<IEnumerable<T>> GetDataFromTable()
    {
        return await _cx.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetTheProvinceByCountryId(Guid id)
    {
        return await _cx.Set<T>()
            .Where(entity => ((IEntity)entity).CountryId == id).ToListAsync();
    }

    public async Task AddNewObject(T obj)
    {
        await _cx.Set<T>().AddAsync(obj);
        await _cx.SaveChangesAsync();
    }
}