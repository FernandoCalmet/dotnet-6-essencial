using aysconsultores.dotnet_web_api_minimal.Entidades;
using aysconsultores.dotnet_web_api_minimal.Persistencia;
using Microsoft.EntityFrameworkCore;

#region Agregar servicios al contenedor.
var builder = WebApplication.CreateBuilder(args);

// Obtenga m�s informaci�n sobre c�mo configurar Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Conexi�n con la base de datos de SQL Server
builder.Services.AddDbContext<ApiContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion"))
);
#endregion

#region Configuraci�n de la canalizaci�n (pipelines) de solicitudes HTTP.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
#endregion

#region Endpoints de Articulos

#region Obtener todos los art�culos
app.MapGet("/articulos", async (ApiContexto contexto) =>
    Results.Ok(await contexto.Articulos.ToListAsync())).WithName("ObtenerArticulos");
#endregion

#region Obtener un art�culo por ID
app.MapGet("/articulos/{id}", async (ApiContexto contexto, int id) =>
    {
        var articulo = await contexto.Articulos.FindAsync(id);
        return articulo != null ? Results.Ok(articulo) : Results.NotFound();
    }).WithName("ObtenerArticulo");
#endregion

#region Crear un art�culo
app.MapPost("/articulos", async (ApiContexto contexto, Articulo articulo) =>
    {
        var articuloCreado = contexto.Articulos.AddAsync(new Articulo
        {
            Titulo = articulo.Titulo ?? string.Empty,
            Contenido = articulo.Contenido ?? string.Empty,
            FechaPublicacion = articulo.FechaPublicacion ?? DateTime.MinValue
        });
        await contexto.SaveChangesAsync();
        return Results.Created($"/articulos/{articuloCreado.Result.Entity.Id}", articuloCreado.Result.Entity);
    }).WithName("CrearArticulo");
#endregion

#region Actualizar un art�culo
app.MapPut("/articulos/{id}", async (ApiContexto contexto, int id, Articulo articulo) =>
    {
        var articuloEncontrado = await contexto.Articulos.FindAsync(id);
        if (articuloEncontrado == null)
            return Results.NotFound();
        articuloEncontrado.Titulo = articulo.Titulo ?? articuloEncontrado.Titulo;
        articuloEncontrado.Contenido = articulo.Contenido ?? articuloEncontrado.Contenido;
        articuloEncontrado.FechaPublicacion = articulo.FechaPublicacion ?? articuloEncontrado.FechaPublicacion;
        await contexto.SaveChangesAsync();
        return Results.Ok(articuloEncontrado);
    }).WithName("ModificarArticulo");
#endregion

#region Eliminar un art�culo
app.MapDelete("/articulos/{id}", async (ApiContexto contexto, int id) =>
    {
        var articuloEncontrado = await contexto.Articulos.FindAsync(id);
        if (articuloEncontrado == null)
            return Results.NotFound();
        contexto.Articulos.Remove(articuloEncontrado);
        await contexto.SaveChangesAsync();
        return Results.Ok();
    }).WithName("EliminarArticulo");
#endregion

#endregion

app.Run();