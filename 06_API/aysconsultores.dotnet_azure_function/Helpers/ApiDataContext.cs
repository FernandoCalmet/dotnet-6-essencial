using aysconsultores.dotnet_azure_function.Entities;
using aysconsultores.dotnet_azure_function.Enums;
using Microsoft.EntityFrameworkCore;

namespace aysconsultores.dotnet_azure_function.Helpers;

public class ApiDataContext : DbContext
{
    public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region User Identity
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
        #endregion

        #region Seed Demo Data
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "Fernando", LastName = "Calmet", Username = "fcalmet", Password = "12345678", Email = "fernando.calmet@aysconsultores.pe", Gender = (byte)UserGender.Male },
            new User { Id = 2, FirstName = "Maria", LastName = "Injante", Username = "minjante", Password = "12345678", Email = "maria.injante@aysconsultores.pe", Gender = (byte)UserGender.Female },
            new User { Id = 3, FirstName = "Carlos", LastName = "Perez", Username = "cperez", Password = "12345678", Email = "carlos.perez@aysconsultores.pe", Gender = (byte)UserGender.Male }
        );
        #endregion
    }
}