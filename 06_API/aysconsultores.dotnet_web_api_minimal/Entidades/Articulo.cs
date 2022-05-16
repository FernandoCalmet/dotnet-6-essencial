namespace aysconsultores.dotnet_web_api_minimal.Entidades;

public class Articulo
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Contenido { get; set; }
    public DateTime? FechaPublicacion { get; set; }
}
