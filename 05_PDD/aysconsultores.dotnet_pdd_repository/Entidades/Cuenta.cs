namespace aysconsultores.dotnet_pdd_repository.Entidades;

public class Cuenta
{
    public Guid CuentaId { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string? TipoCuenta { get; set; }
    public double Saldo { get; set; }
    public Guid UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
}
