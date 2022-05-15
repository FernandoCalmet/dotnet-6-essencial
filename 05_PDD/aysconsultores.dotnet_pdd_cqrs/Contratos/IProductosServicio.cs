using aysconsultores.dotnet_pdd_cqrs.Comandos.ProductoComando;
using aysconsultores.dotnet_pdd_cqrs.Consultas.ProductoConsulta;
using aysconsultores.dotnet_pdd_cqrs.Modelos;

namespace aysconsultores.dotnet_pdd_cqrs.Contratos;

public interface IProductosServicio
{
    Producto HandleComando(AgregarProductoComando comando);
    Producto HandleComando(ModificarProductoComando comando);

    Producto HandleConsulta(BuscarProductoConsulta consulta);
    Producto HandleConsulta(VerificarSiExisteProductoConsulta consulta);
}
