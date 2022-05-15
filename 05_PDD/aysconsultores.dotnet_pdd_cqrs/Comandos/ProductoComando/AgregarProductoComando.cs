namespace aysconsultores.dotnet_pdd_cqrs.Comandos.ProductoComando;

public record AgregarProductoComando(string Nombre, string? Descripcion, decimal Precio);