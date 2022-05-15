#region Productos
using aysconsultores.dotnet_pdd_cqrs.Comandos.ProductoComando;
using aysconsultores.dotnet_pdd_cqrs.Consultas.ProductoConsulta;
using aysconsultores.dotnet_pdd_cqrs.Proveedores;
using aysconsultores.dotnet_pdd_cqrs.Servicios;

var productosServicio = new ProductosServicio(new ProductosProveedor());

#region Agregar Producto
//var productoAgregado = productosServicio.HandleComando(new AgregarProductoComando("Producto nuevo", "Descripcion del nuevo producto", 70));
//Console.WriteLine($"Producto agregado: {productoAgregado.Id} - {productoAgregado.Nombre} - {productoAgregado.Precio} - {productoAgregado.Descripcion}");
#endregion

#region Modificar Producto
//var productoModificado = productosServicio.HandleComando(new ModificarProductoComando(productoAgregado.Id, "Producto modificado", "Descripcion del producto modificado", 80));
//Console.WriteLine($"Producto modificado: {productoModificado.Id} - {productoModificado.Nombre} - {productoModificado.Precio} - {productoModificado.Descripcion}");
#endregion

#region Buscar Producto
//var productoEncontrado = productosServicio.HandleConsulta(new BuscarProductoConsulta("23623687-4b24-40b9-81af-cf402b46ff70"));
//Console.WriteLine($"Producto encontrado: {productoEncontrado.Id} - {productoEncontrado.Nombre} - {productoEncontrado.Precio} - {productoEncontrado.Descripcion}");
#endregion

#region Verificar Si Existe Producto
//var productoVerificado = productosServicio.HandleConsulta(new VerificarSiExisteProductoConsulta(new Guid("23623687-4b24-40b9-81af-cf402b46ff70")));
//Console.WriteLine($"Producto verificado: {productoVerificado.Id} - {productoVerificado.Nombre} - {productoVerificado.Precio} - {productoVerificado.Descripcion}");
#endregion

#endregion