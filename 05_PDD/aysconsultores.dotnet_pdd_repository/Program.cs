using aysconsultores.dotnet_pdd_repository.Entidades;
using aysconsultores.dotnet_pdd_repository.Proveedores;
using aysconsultores.dotnet_pdd_repository.Repositorios;

Console.WriteLine("Hello World!");

#region Repositorio de Usuarios
//var usuariosRepositorio = new UsuariosRepositorio(new ContextoRepositorio());

#region Buscar todos los usuarios
//var usuarios = usuariosRepositorio.BuscarTodos();
//foreach (var u in usuarios)
//{
//    Console.WriteLine($" Id: {u.UsuarioId}, Nombre: {u.Nombre}, Fecha de Nacimiento: {u.FechaNacimiento}");
//}
#endregion

#region Buscar un usuario por id
//var usuarioId = new Guid("ae9879fa-ebbb-4d3f-b721-8e9996472bc5");
//var usuarioEncontrado = usuariosRepositorio.BuscarPorId(usuarioId);
//Console.WriteLine($" Id: {usuarioEncontrado.UsuarioId}, Nombre: {usuarioEncontrado.Nombre}, Fecha de Nacimiento: {usuarioEncontrado.FechaNacimiento}");
#endregion

#region Agregar usuario
//var usuarioNuevo = new Usuario()
//{
//    UsuarioId = new Guid("86765651-67c5-47d0-b2d0-0b1812f51210"),
//    Nombre = "Cesar",
//    FechaNacimiento = new DateOnly(1985, 1, 1)
//};
//var usuarioCreado = usuariosRepositorio.Agregar(usuarioNuevo);
//Console.WriteLine($" Id: {usuarioCreado.UsuarioId}, Nombre: {usuarioCreado.Nombre}, Fecha de Nacimiento: {usuarioCreado.FechaNacimiento}");
#endregion

#region Modificar usuario
//usuarioNuevo.Nombre = "Mauricio";
//var usuarioModificado = usuariosRepositorio.Modificar(usuarioNuevo);
//Console.WriteLine($" Id: {usuarioModificado.UsuarioId}, Nombre: {usuarioModificado.Nombre}, Fecha de Nacimiento: {usuarioModificado.FechaNacimiento}");
#endregion

#region Eliminar usuario
//var usuarioEliminado = usuariosRepositorio.Eliminar(usuarioModificado);
//if (usuarioEliminado) Console.WriteLine("Se elimino el usuario exitosamente");
#endregion

#endregion

#region Repositorio de Cuentas
//var cuentasRepositorio = new CuentasRepositorio(new ContextoRepositorio());

#region Buscar todas las cuentas
//var cuentas = cuentasRepositorio.BuscarTodos();
//foreach (var c in cuentas)
//{
//    Console.WriteLine($" Id: {c.CuentaId}, Fecha de Registro: {c.FechaRegistro}, Tipo de Cuenta: {c.TipoCuenta}, Saldo: {c.Saldo}, UsuarioId: {c.UsuarioId}");
//}
#endregion

#region Buscar una cuenta por id
//var cuentaId = new Guid("623081d9-9837-4198-a5d8-1a08a6298e34");
//var cuentaEncontrada = cuentasRepositorio.BuscarPorId(cuentaId);
//Console.WriteLine($" Id: {cuentaEncontrada.CuentaId}, Fecha de Registro: {cuentaEncontrada.FechaRegistro}, Tipo de Cuenta: {cuentaEncontrada.TipoCuenta}, Saldo: {cuentaEncontrada.Saldo}, UsuarioId: {cuentaEncontrada.UsuarioId}");
#endregion

#region Buscar una cuenta por usuario
//var cuentaUsuarioId = new Guid("ae9879fa-ebbb-4d3f-b721-8e9996472bc5");
//var usuario2Encontrado = usuariosRepositorio.BuscarPorId(cuentaUsuarioId);
//var cuentaUsuarioEncontrada = cuentasRepositorio.BuscarPorUsuario(usuario2Encontrado);
//Console.WriteLine($" Id: {cuentaUsuarioEncontrada.CuentaId}, Fecha de Registro: {cuentaUsuarioEncontrada.FechaRegistro}, Tipo de Cuenta: {cuentaUsuarioEncontrada.TipoCuenta}, Saldo: {cuentaUsuarioEncontrada.Saldo}, UsuarioId: {cuentaUsuarioEncontrada.UsuarioId}, Nombre de usuario: {usuario2Encontrado.Nombre}");
#endregion

#region Agregar cuenta
//var cuentaNueva = new Cuenta()
//{
//CuentaId = new Guid("2f4bd369-37da-45e5-848e-0e634a597845"),
//TipoCuenta = "Ahorros",
//Saldo = 200,
//UsuarioId = new Guid("86765651-67c5-47d0-b2d0-0b1812f51210")
//};
//var cuentaCreada = cuentasRepositorio.Agregar(cuentaNueva);
//Console.WriteLine($" Id: {cuentaCreada.CuentaId}, Fecha de Registro: {cuentaCreada.FechaRegistro}, Tipo de Cuenta: {cuentaCreada.TipoCuenta}, Saldo: {cuentaCreada.Saldo}, UsuarioId: {cuentaCreada.UsuarioId}");
#endregion

#region Modificar cuenta
//cuentaNueva.Saldo += 50;
//var cuentaModificada = cuentasRepositorio.Modificar(cuentaNueva);
//Console.WriteLine($" Id: {cuentaModificada.CuentaId}, Fecha de Registro: {cuentaModificada.FechaRegistro}, Tipo de Cuenta: {cuentaModificada.TipoCuenta}, Saldo: {cuentaModificada.Saldo}, UsuarioId: {cuentaModificada.UsuarioId}");
#endregion

#region Eliminar cuenta
//var cuentaEliminada = cuentasRepositorio.Eliminar(cuentaModificada);
//if (cuentaEliminada) Console.WriteLine("Se elimino la cuenta exitosamente");
#endregion

#endregion