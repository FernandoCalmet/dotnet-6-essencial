using aysconsultores.dotnet_pdd_cqrs.Comandos.ProductoComando;
using aysconsultores.dotnet_pdd_cqrs.Consultas.ProductoConsulta;
using aysconsultores.dotnet_pdd_cqrs.Contratos;
using aysconsultores.dotnet_pdd_cqrs.Modelos;
using aysconsultores.dotnet_pdd_cqrs.Proveedores;

namespace aysconsultores.dotnet_pdd_cqrs.Servicios;

public class ProductosServicio : IProductosServicio
{
    private readonly ProductosProveedor _contextoServicio;

    public ProductosServicio(ProductosProveedor contextoServicio)
    {
        _contextoServicio = contextoServicio;
    }

    public Producto HandleComando(AgregarProductoComando comando)
    {
        var producto = new Producto(Guid.NewGuid(), comando.Nombre, comando.Descripcion, comando.Precio);
        _contextoServicio.Productos.Add(producto);
        return producto;
    }

    public Producto HandleComando(ModificarProductoComando comando)
    {
        var producto = _contextoServicio.Productos.FirstOrDefault(x => x.Id == comando.Id);
        var productoModificado = new Producto(producto.Id, comando.Nombre, comando.Descripcion, comando.Precio);
        _contextoServicio.Productos.Remove(producto);
        _contextoServicio.Productos.Add(productoModificado);
        return productoModificado;
    }

    public Producto HandleConsulta(BuscarProductoConsulta consulta)
    {
        bool esGuid = Guid.TryParse(consulta.Valor, out Guid id);
        if (esGuid)
        {
            return _contextoServicio.Productos.FirstOrDefault(x => x.Id == id);
        }
        else
        {
            return _contextoServicio.Productos.FirstOrDefault(x => x.Nombre == consulta.Valor);
        }
    }

    public Producto HandleConsulta(VerificarSiExisteProductoConsulta consulta)
    {
        return _contextoServicio.Productos.FirstOrDefault(x => x.Id == consulta.Id);
    }
}
