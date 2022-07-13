#region dependencias
using aysconsultores.dotnet_web_api_minimal.Autenticacion;
using aysconsultores.dotnet_web_api_minimal.Entidades;
using aysconsultores.dotnet_web_api_minimal.Persistencia;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
#endregion

#region Agregar servicios al contenedor.
var builder = WebApplication.CreateBuilder(args);

// Obtenga más información sobre cómo configurar Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Conexión con la base de datos de SQL Server
builder.Services.AddDbContext<ApiContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion"))
);
// Servicio de autenticación JWT
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
// Servivio de autorización JWT
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
#endregion

#region Configuración de la canalización (pipelines) de solicitudes HTTP.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware de autenticación JWT
app.UseAuthentication();
// Middleware de autorización JWT
app.UseAuthorization();
#endregion

#region Endpoint de autenticación JWT
app.MapPost("/seguridad/obtenerToken", [AllowAnonymous] (UsuarioDTO usuario) =>
{

    if (usuario.Correo == "fernando.calmet@aysconsultores.pe" && usuario.Contrasena == "P@ssword")
    {
        var issuer = builder.Configuration["Jwt:Issuer"];
        var audience = builder.Configuration["Jwt:Audience"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Ahora es el momento de definir el token jwt que se encargará de crear nuestros tokens.
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        // Obtenemos nuestro secreto de la configuración de la aplicación.
        var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

        // definimos nuestro descriptor de token
        // Necesitamos utilizar reclamos que son propiedades en nuestro token que brindan información sobre el token
        // que pertenecen al usuario específico al que pertenece
        // por lo que podría contener su id, nombre, correo electrónico lo bueno es que esta información
        // son generados por nuestro servidor y marco de identidad que es válido y confiable
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", "1"),
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Correo),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Correo),
                // el JTI se usa para nuestro token de actualización
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            // la vida útil del token debe ser más corta y utilizar el token de actualización para mantener la sesión del usuario
            // pero dado que esta es una aplicación de demostración, podemos ampliarla para que se ajuste a nuestra necesidad actual
            Expires = DateTime.UtcNow.AddHours(6),
            Audience = audience,
            Issuer = issuer,
            // aquí estamos agregando la información del algoritmo de cifrado que se utilizará para descifrar nuestro token
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        var jwtToken = jwtTokenHandler.WriteToken(token);

        return Results.Ok(jwtToken);
    }
    else
    {
        return Results.Unauthorized();
    }
});
#endregion

#region Endpoints de Articulos
const string articulosRoute = "api/articulos";

#region Obtener todos los artículos
app.MapGet(articulosRoute, [Authorize] async (ApiContexto contexto) =>
    Results.Ok(await contexto.Articulos.ToListAsync())).WithName("ObtenerArticulos");
#endregion

#region Obtener un artículo por ID
app.MapGet(articulosRoute + "/{id}", [Authorize] async (ApiContexto contexto, int id) =>
    {
        var articulo = await contexto.Articulos.FindAsync(id);
        return articulo != null ? Results.Ok(articulo) : Results.NotFound();
    }).WithName("ObtenerArticulo");
#endregion

#region Crear un artículo
app.MapPost(articulosRoute, [Authorize] async (ApiContexto contexto, Articulo articulo) =>
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

#region Actualizar un artículo
app.MapPut(articulosRoute + "/{id}", [Authorize] async (ApiContexto contexto, int id, Articulo articulo) =>
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

#region Eliminar un artículo
app.MapDelete(articulosRoute + "/{id}", [Authorize] async (ApiContexto contexto, int id) =>
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