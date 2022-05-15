using aysconsultores.dotnet_pdd_repository.Contratos;
using aysconsultores.dotnet_pdd_repository.Entidades;
using aysconsultores.dotnet_pdd_repository.Proveedores;

namespace aysconsultores.dotnet_pdd_repository.Repositorios;

public class CuentasRepositorio : ICuentasRepositorio
{
    private readonly ContextoRepositorio _contextoRepositorio;

    public CuentasRepositorio(ContextoRepositorio contextoRepositorio)
    {
        _contextoRepositorio = contextoRepositorio;
    }

    public Cuenta Agregar(Cuenta entidad)
    {
        var cuentas = _contextoRepositorio.Cuentas.ToList();
        cuentas.Add(entidad);
        return entidad;
    }

    public Cuenta Modificar(Cuenta entidad)
    {
        var cuentas = _contextoRepositorio.Cuentas.ToList();
        var cuenta = cuentas.Find(x => x.CuentaId == entidad.CuentaId);
        var cuentaModificada = new Cuenta
        {
            UsuarioId = entidad.UsuarioId,
            Usuario = entidad.Usuario
        };
        cuentas.Remove(cuenta);
        cuentas.Add(cuentaModificada);
        return cuentaModificada;
    }

    public bool Eliminar(Cuenta entidad)
    {
        var cuentas = _contextoRepositorio.Cuentas.ToList();
        var cuenta = cuentas.Find(x => x.CuentaId == entidad.CuentaId);
        cuentas.Remove(cuenta);
        return true;
    }

    public IEnumerable<Cuenta> BuscarTodos()
    {
        return _contextoRepositorio.Cuentas.ToList();
    }

    public Cuenta BuscarPorId(Guid id)
    {
        var cuentas = _contextoRepositorio.Cuentas.ToList();
        return cuentas.Find(x => x.CuentaId == id);
    }

    public Cuenta BuscarPorUsuario(Usuario usuario)
    {
        var cuentas = _contextoRepositorio.Cuentas.ToList();
        return cuentas.Find(x => x.UsuarioId == usuario.UsuarioId);
    }
}
