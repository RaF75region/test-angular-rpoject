using back.api.SeedData;
using back.domain;
using back.domain.Interfaces;
using back.infrastructure;
using back.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TestProject;

public class TestRepository
{
    private IConfiguration _configuration;
    private string connectionString = String.Empty;

    private DbContextOptions<MyDbContext> _options;
    
    
    [SetUp]
    public async Task Setup()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

        _configuration = builder.Build();
        connectionString = _configuration.GetValue<string>("testConnectionString");
        _options = new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlite(connectionString)
            .Options;
        using (var context = new MyDbContext(_options))
        {
            SeedData s = new SeedData(context);
            await s.SeedDataBase();
        }
       
    }

    [Test]
    public async Task TestGetCountries()
    {
        using (var context = new MyDbContext(_options))
        {
            IRepository<Country> repository = new Repository<Country>(context);
            var result = await repository.GetDataFromTable();
            Assert.IsNotNull(result);
            Assert.True(result.Count() != 0);
        }
    }
    
    [TestCase("BBF58746-483F-4514-8AF5-FBF5A3AA17D6")]
    [TestCase("F7EC09C0-2136-4BCF-9C25-B4FD4F517159")]
    [TestCase("CFC2EF45-708A-45CB-902E-8D0A0F803345")]
    public async Task TestGetProvince(string countryId)
    {
        Guid.TryParse(countryId, out Guid id);
        using (var context = new MyDbContext(_options))
        {
            IRepository<Province> repository = new Repository<Province>(context);
            var result = await repository.GetTheProvinceByCountryId(id);
            Assert.IsNotNull(result);
            Assert.True(result.Count() != 0);
            Assert.True(result.FirstOrDefault().CountryId.ToString().ToUpper().Equals(countryId.ToUpper()));
        }
    }
    
    
    [Test]
    public async Task TestAddUser()
    {
        List<User> listUser = TestDataForAddUser.Users;
        using (var context = new MyDbContext(_options))
        {
            IRepository<User> repository = new Repository<User>(context);
            foreach (var user in listUser)
            {
                var result_before = await repository.GetDataFromTable();
                await repository.AddNewObject(user);
                var result_after = await repository.GetDataFromTable();
                Assert.True(result_after.Count().Equals(result_before.Count()+1));
            }
        }
    }
}