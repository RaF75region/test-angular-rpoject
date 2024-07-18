using back.domain;

namespace TestProject;

public static class TestDataForAddUser
{
    public static new List<User> Users = new()
    {
        new User()
        {
            Id = Guid.NewGuid(),
            Email = "user1@example.com",
            Password = "password123",
            ConfirmPassword = "password123",
            isAgree = true,
            CountryId = new Guid("69BEE761-3B2C-41E6-889B-1D2E1F40A195"),
            ProvinceId = new Guid("0021BCA0-FE88-4D8D-AA88-DD74ECAC6190")
        },
        new User()
        {
            Id = Guid.NewGuid(),
            Email = "user2@example.com",
            Password = "securepass456",
            ConfirmPassword = "securepass456",
            isAgree = true,
            CountryId = new Guid("69BEE761-3B2C-41E6-889B-1D2E1F40A195"),
            ProvinceId = new Guid("5D8CBB72-A6E0-46C8-8C00-C293392822E8")
        },
        new User()
        {
            Id = Guid.NewGuid(),
            Email = "user3@example.com",
            Password = "mypassword789",
            ConfirmPassword = "mypassword789",
            isAgree = true,
            CountryId = new Guid("CFC2EF45-708A-45CB-902E-8D0A0F803345"),
            ProvinceId = new Guid("C48C6681-C550-41B5-8E0B-3880BD4C7AE6")
        }
    };
}