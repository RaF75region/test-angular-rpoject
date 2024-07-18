using back.domain;
using back.domain.Interfaces;

namespace back.infrastructure;

public class RepositoryServices
{
    private readonly IRepository<Country> _countryRepository;
    private readonly IRepository<Province> _provinceRepository;
    
    public RepositoryServices(IRepository<Country> countryRepository, IRepository<Province> provinceRepository)
    {
        _countryRepository = countryRepository;
        _provinceRepository = provinceRepository;
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        return await _countryRepository.GetDataFromTable();
    }

    public async Task<IEnumerable<Province>> GetProvincesByCountryId(Guid id)
    {
        return await _provinceRepository.GetTheProvinceByCountryId(id);
    }

}