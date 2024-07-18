using back.domain;
using back.infrastructure;
using Microsoft.EntityFrameworkCore;

namespace back.api.SeedData;

public class SeedData
{
    private readonly MyDbContext _context;

    public SeedData(MyDbContext context)
    {
        _context = context;
    }

    public async Task SeedDataBase()
    {
        await _context.Database.MigrateAsync();
        if (_context.Countries.Count().Equals(0) && _context.Provinces.Count().Equals(0))
        {
            await _context.Countries.AddRangeAsync(countries);
            await _context.SaveChangesAsync();
        }
    }

    private Country[] countries => new[]
    {
        new Country() { Name = "Country 1", Provincies = new []
            {
            new Province() { Name = "Province 1" },
            new Province() { Name = "Province 11" },
        }},
        new Country() { Name = "Country 2" , Provincies = new []
        {
            new Province() { Name = "Province 2" },
            new Province() { Name = "Province 21" },
        }},
        new Country() { Name = "Country 3", Provincies = new []
            {
            new Province() { Name = "Province 3" },
            new Province() { Name = "Province 31" },
        }},
        new Country() { Name = "Country 4", Provincies = new []
        {
            new Province() { Name = "Province 4" },
            new Province() { Name = "Province 41" },
        }},
        new Country() { Name = "Country 5", Provincies = new []
        {
            new Province() { Name = "Province 5" },
            new Province() { Name = "Province 51" },
        }},
        new Country() { Name = "Country 6", Provincies = new []
            {
            new Province() { Name = "Province 5" },
            new Province() { Name = "Province 51" },
        } },
    };
}