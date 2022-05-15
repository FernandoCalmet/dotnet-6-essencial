using aysconsultores.dotnet_pdd_repository.Entidades;

namespace aysconsultores.dotnet_pdd_repository.Proveedores;

public class ContextoRepositorio
{
    public List<Usuario> Usuarios { get; set; }
    public List<Cuenta> Cuentas { get; set; }

    public ContextoRepositorio()
    {
        Usuarios = new();
        Usuarios = new UsuariosProveedor().Usuarios;

        Cuentas = new();
        Cuentas = new CuentasProveedor().Cuentas;
    }
}
