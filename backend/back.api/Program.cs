using back.api.Controllers;
using back.api.SeedData;
using back.domain.Interfaces;
using back.infrastructure;
using back.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetValue<string>("connectionString");
var  corsOrigin = "corsOrigin";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsOrigin,
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<SeedData>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddTransient<RepositoryServices>();
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    opt.UseSqlite(connectionString, b=>
        b.MigrationsAssembly("back.api"));
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<MyDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while applying migrations.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsOrigin);
app.UseHttpsRedirection();

Requests.CountryRequests(app);

app.Run();