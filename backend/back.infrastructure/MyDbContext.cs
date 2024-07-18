using back.domain;
using Microsoft.EntityFrameworkCore;
namespace back.infrastructure;

public class MyDbContext:DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
}