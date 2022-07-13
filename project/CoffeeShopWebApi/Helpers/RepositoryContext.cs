using Microsoft.EntityFrameworkCore;

namespace CoffeeShopWebApi.Helpers;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
    {
    }
    public DbSet<Coffee>? Coffees { get; set; }
}