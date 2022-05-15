using aysconsultores.dotnet_pdd_cqrs.Modelos;

namespace aysconsultores.dotnet_pdd_cqrs.Proveedores;

public class ProductosProveedor
{
    public List<Producto> Productos { get; set; }

    public ProductosProveedor()
    {
        Productos = new();

        Productos.Add(new Producto
        {
            Id = new Guid("23623687-4b24-40b9-81af-cf402b46ff70"),
            Nombre = "Producto 1",
            Descripcion = "Descripcion del producto 1",
            Precio = 100
        });
        Productos.Add(new Producto
        {
            Id = new Guid("165c22b3-47b4-4287-9285-48f00007cc9a"),
            Nombre = "Producto 2",
            Descripcion = "Descripcion del producto 2",
            Precio = 23
        });
        Productos.Add(new Producto
        {
            Id = new Guid("d588f6b6-8f5d-40da-878d-5c1091190813"),
            Nombre = "Producto 3",
            Descripcion = "Descripcion del producto 3",
            Precio = 340
        });
        Productos.Add(new Producto
        {
            Id = new Guid("61ef7506-746e-465e-b4b3-d74cb8dab232"),
            Nombre = "Producto 4",
            Descripcion = "Descripcion del producto 4",
            Precio = 60
        });
        Productos.Add(new Producto
        {
            Id = new Guid("a7c659b3-2767-43d0-83bd-19b32c438254"),
            Nombre = "Producto 5",
            Descripcion = "Descripcion del producto 5",
            Precio = 280
        });
    }
}
