namespace aysconsultores.dotnet_pdd_cqrs.Modelos;

public class Producto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }

    public Producto() { }

    public Producto(Guid id, string nombre, string? descripcion, decimal precio)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
    }
}
