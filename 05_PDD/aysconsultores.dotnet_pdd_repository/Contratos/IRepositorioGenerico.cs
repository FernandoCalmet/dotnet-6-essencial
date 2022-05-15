namespace aysconsultores.dotnet_pdd_repository.Contratos;

public interface IRepositorioGenerico<Entidad> where Entidad : class
{
    Entidad Agregar(Entidad entidad);
    Entidad Modificar(Entidad entidad);
    bool Eliminar(Entidad entidad);    
    IEnumerable<Entidad> BuscarTodos();
    Entidad BuscarPorId(Guid id);
}
