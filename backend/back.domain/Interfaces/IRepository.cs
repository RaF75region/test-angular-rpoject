namespace back.domain.Interfaces;

public interface IRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetDataFromTable();
    public Task<IEnumerable<T>> GetTheProvinceByCountryId(Guid id);
    public Task AddNewObject(T obj);
}