namespace aysconsultores.dotnet_pdd_repository.Entidades;

public class Usuario
{
    public Guid UsuarioId { get; set; }
    public string? Nombre { get; set; }
    public DateOnly FechaNacimiento { get; set; }
}
