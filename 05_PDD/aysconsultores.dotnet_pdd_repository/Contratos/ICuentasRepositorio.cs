using aysconsultores.dotnet_pdd_repository.Entidades;

namespace aysconsultores.dotnet_pdd_repository.Contratos;

public interface ICuentasRepositorio : IRepositorioGenerico<Cuenta>
{
    Cuenta BuscarPorUsuario(Usuario usuario);
}
