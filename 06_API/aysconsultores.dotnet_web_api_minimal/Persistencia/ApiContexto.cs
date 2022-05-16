using aysconsultores.dotnet_web_api_minimal.Entidades;
using Microsoft.EntityFrameworkCore;

namespace aysconsultores.dotnet_web_api_minimal.Persistencia;

public class ApiContexto : DbContext
{
    public ApiContexto(DbContextOptions<ApiContexto> options) : base(options) { }

    public DbSet<Articulo> Articulos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Articulo Identity
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
        #endregion

        #region Seed de tabla Articulo
        modelBuilder.Entity<Articulo>().HasData(
            new Articulo { Id = 1, Titulo = "Articulo 1", Contenido = "Contenido de Articulo 1", FechaPublicacion = DateTime.UtcNow },
            new Articulo { Id = 2, Titulo = "Articulo 2", Contenido = "Contenido de Articulo 2", FechaPublicacion = DateTime.UtcNow },
            new Articulo { Id = 3, Titulo = "Articulo 3", Contenido = "Contenido de Articulo 3", FechaPublicacion = DateTime.UtcNow },
            new Articulo { Id = 4, Titulo = "Articulo 4", Contenido = "Contenido de Articulo 4", FechaPublicacion = DateTime.UtcNow },
            new Articulo { Id = 5, Titulo = "Articulo 5", Contenido = "Contenido de Articulo 5", FechaPublicacion = DateTime.UtcNow },
            new Articulo { Id = 6, Titulo = "Articulo 6", Contenido = "Contenido de Articulo 6", FechaPublicacion = DateTime.UtcNow }
        );
        #endregion
    }
}
