using aysconsultores.dotnet_pdd_repository.Contratos;
using aysconsultores.dotnet_pdd_repository.Entidades;
using aysconsultores.dotnet_pdd_repository.Proveedores;

namespace aysconsultores.dotnet_pdd_repository.Repositorios;

public class UsuariosRepositorio : IUsuariosRepositorio
{
    private readonly ContextoRepositorio _contextoRepositorio;

    public UsuariosRepositorio(ContextoRepositorio contextoRepositorio)
    {
        _contextoRepositorio = contextoRepositorio;
    }

    public Usuario Agregar(Usuario entidad)
    {
        var usuarios = _contextoRepositorio.Usuarios.ToList();
        usuarios.Add(entidad);
        return entidad;
    }

    public Usuario Modificar(Usuario entidad)
    {
        var usuarios = _contextoRepositorio.Usuarios.ToList();
        var usuario = usuarios.Find(x => x.UsuarioId == entidad.UsuarioId);
        var usuarioModificado = new Usuario
        {
            Nombre = entidad.Nombre,
            FechaNacimiento = entidad.FechaNacimiento
        };
        usuarios.Remove(usuario);
        usuarios.Add(usuarioModificado);
        return usuarioModificado;
    }

    public bool Eliminar(Usuario entidad)
    {
        var usuarios = _contextoRepositorio.Usuarios.ToList();
        var usuario = usuarios.Find(x => x.UsuarioId == entidad.UsuarioId);
        usuarios.Remove(usuario);
        return true;
    }

    public IEnumerable<Usuario> BuscarTodos()
    {
        return _contextoRepositorio.Usuarios.ToList();
    }

    public Usuario BuscarPorId(Guid id)
    {
        var usuarios = _contextoRepositorio.Usuarios.ToList();
        return usuarios.Find(x => x.UsuarioId == id);
    }
}
