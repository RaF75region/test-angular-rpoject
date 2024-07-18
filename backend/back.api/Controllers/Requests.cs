using back.domain;
using back.domain.Interfaces;
using back.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace back.api.Controllers;

public static class Requests
{
    public static void CountryRequests(WebApplication app)
    {
        app.MapGet("/seed-test-data", async (SeedData.SeedData sd) =>
            {
                try
                {

                    await sd.SeedDataBase();
                    return Results.Ok();
                }
                catch (Exception e)
                {
                    return Results.Conflict(error: e.Message);
                }
            })
            .WithName("SeedTestData")
            .WithOpenApi();
        app.MapGet("/get-countries", async (
                IRepository<Country> repository
            ) => await repository.GetDataFromTable())
            .WithName("GetCountries")
            .WithOpenApi();
        app.MapGet("/get-provincies/{countryId}", async (
                Guid countryId,
                IRepository<Province> repository
            ) => await repository.GetTheProvinceByCountryId(countryId))
            .WithName("GetProvincies")
            .WithOpenApi();
        app.MapPost("/add-new-object", async (
                [FromBody] User user,
                IRepository<User> repository) =>
            {
                try
                {
                    await repository.AddNewObject(user);
                    return Results.Ok(user);
                }
                catch (Exception e)
                {
                    return Results.Conflict(e.Message);
                }
            })
            .WithName("AddNewObject")
            .WithOpenApi();
        ;
    }
}