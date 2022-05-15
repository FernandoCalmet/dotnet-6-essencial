namespace aysconsultores.dotnet_pdd_cqrs.Comandos.ProductoComando;

public record ModificarProductoComando(Guid Id, string Nombre, string? Descripcion, decimal Precio);