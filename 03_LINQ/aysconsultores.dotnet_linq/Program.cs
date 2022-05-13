#region Metodos de extensión y expresiones lambda  

#region Metodos de extensión
//string[] niveles = { "Basico", "Intermedio", "Avanzado" };
//var conteoNiveles = niveles.Count();
//Console.WriteLine(conteoNiveles);

//Object[] arreglo = { "LinkedIn", 'L', 25, false };
//int arregloT = arreglo.Count();
//Console.WriteLine(arregloT);
#endregion

#region Sintaxis basada en expresiones lambda
//string[] niveles = { "Basico", "Intermedio", "Avanzado" };
//int maximo = 6;

//var nivelesMaximo = niveles
//                        .Where(nivel => nivel.Length > maximo)
//                        .OrderBy(ordenNivel => ordenNivel);

//foreach (var nivel in nivelesMaximo)
//{
//    Console.WriteLine(nivel);
//}
#endregion

#region Sintaxis basada en consultas (expresion de consultas)
//string[] niveles = { "Basico", "Intermedio", "Avanzado" };
//int maximo = 6;

//var consultaNivel =
//    from nivel in niveles
//    where nivel.Length > maximo
//    orderby nivel ascending
//    select nivel;

//foreach (var nivel in consultaNivel)
//{
//    Console.WriteLine(nivel);
//}
#endregion

#endregion

#region Consultas
//using aysconsultores.dotnet_linq.Consultas;

//var proveedor = new EmpleadosProvider();
//var empleados = proveedor.ListarEmpleados();

#region Consultas con expresiones lambda
//var empleado = empleados
//                .Where(e =>
//                   e.Departamento == Departamento.Desarrollo
//                   && e.Nombre.ToLower().Contains("f"))
//                .OrderBy(e => e.Id)
//                .Select(u => new
//                {
//                    u.Id,
//                    u.Nombre,
//                    InicialApellido = u.Apellido.Substring(0, 1),
//                    Dpto = u.Departamento.ToString(),
//                });

//var encabezado = string.Format("{0,-40} {1,-10} {2,-10} {3,-10}", "ID", "Nombre", "Apellido", "Departamento");
//Console.WriteLine(encabezado);

//foreach (var f in empleado)
//{
//    string fila = string.Format("{0,-40} {1,-10} {2,-10} {3,-10}", f.Id, f.Nombre, f.InicialApellido, f.Dpto);
//    Console.WriteLine(fila);
//}
#endregion

#region consultas con expresiones de consulta
//var empleado =
//    from e in empleados
//    where (e.Departamento == Departamento.Desarrollo && e.Nombre.ToLower().Contains("f"))
//    orderby e.Nombre descending
//    select new
//    {
//        e.Id,
//        e.Nombre,
//        InicialApellido = e.Apellido.Substring(0, 1),
//        Dpto = e.Departamento.ToString(),
//    };
//foreach (var f in empleado)
//{
//    string fila = string.Format("{0,-40} {1,-10} {2,-10} {3,-10}", f.Id, f.Nombre, f.InicialApellido, f.Dpto);
//    Console.WriteLine(fila);
//}
#endregion

#endregion

#region Operadores
//using aysconsultores.dotnet_linq.Operadores;

//var listaEmpleados = new EmpleadosProvider().ListarEmpleados();
//var listaPagos = new PagosProvider().ListarPagos();

#region Operadores para filtrar, ordenar y agrupar

#region filtrar listaEmpleados mayor o igual a 30 de edad
//var filtro = listaEmpleados.Where(e => e.Edad <= 30).Reverse();
//MensajeHelper.ImprimeEmpleados(filtro, "REVERSE");
#endregion

#region filtrado para saltar n cantidad de elementos
//var fs = listaEmpleados.Where(e => e.Edad <= 30).Skip(1);
//MensajeHelper.ImprimeEmpleados(fs, "SKIP");
#endregion

#region filtrar tomando ciertos elementos
//var ft = listaEmpleados.Where(e => e.Edad <= 30).TakeWhile(e => e.Edad <= 25);
//MensajeHelper.ImprimeEmpleados(ft, "TAKE_WHILE");
#endregion

#region Filtrar, ordenar y agrupar
//var foa = listaEmpleados.Where(e => e.Edad <= 30)
//    .OrderBy(e => e.Nombre)
//    .GroupBy(e => e.Departamento);

//foa.ToList(); //debugear el resultado
#endregion

#endregion

#region Operadores de proyeccion y cuantificacion

#region operador de proyeccion: select
//var pagos = listaEmpleados.Where(e => e.Departamento == Departamento.Desarrollo)
//    .Select(e => e.Pagos);
//pagos.ToList(); //Debugear el resultado
#endregion

#region operador de proyeccion: select many
//var pagosMany = listaEmpleados.Where(e => e.Departamento == Departamento.Desarrollo
//        && e.Pagos != null)
//    .SelectMany(e => e.Pagos, (e, pago) => new
//    {
//        e.Nombre,
//        pago.Descripcion,
//        pago.Monto
//    });
//pagosMany.ToList(); //Debugear el resultado
#endregion

#region operador de cuantificacion: any (devuelve verdadero si al menos uno de los elementos cumple con la condicion especificada)
//var monto = 20000f;
//var existePagoMenor = pagosMany.Any(p => p.Monto <= monto);
//existePagoMenor.ToString(); //Debugear el resultado
#endregion

#region operador de cuantificacion: all (devuelve verdadero si todos los elementos cumple con la condicion especificada)
//var existPagoMayor = pagosMany.All(p => p.Monto >= monto);
//existPagoMayor.ToString(); //Debugear el resultado
#endregion

#endregion

#region Operadores de agregacion y conversion
//var pagosEmpleados = listaEmpleados
//    .Where(e => e.Pagos != null)
//    .SelectMany(e => e.Pagos, (e, pago) => new
//    {
//        e.Nombre,
//        pago.Descripcion,
//        pago.Monto
//    });

//var cantidadPagos = pagosEmpleados.Count();

#region average
//var promedioPagos = pagosEmpleados.Average(p => p.Monto);
//Console.WriteLine($"Promedio de monto {promedioPagos}");
#endregion

#region min
//var pagoMin = pagosEmpleados.Min(p => p.Monto);
//Console.WriteLine($"Pago mínimo {pagoMin}");
#endregion

#region max
//var pagoMax = pagosEmpleados.Max(p => p.Monto);
//Console.WriteLine($"Pago maximo {pagoMax}");
#endregion

#region conversión
//var arr = pagosEmpleados.ToArray();
//var ls = pagosEmpleados.ToList();
#endregion

#endregion

#region Operadores de elemento
//var pagosEmpleados = listaEmpleados
//    .Where(e => e.Pagos != null)
//    .SelectMany(e => e.Pagos, (e, pago) => new
//    {
//        e.Nombre,
//        pago.Descripcion,
//        pago.Monto
//    });

#region first
//var fPago = pagosEmpleados.First(p => p.Monto < 15000f);
//Console.WriteLine($"Primer pago: {fPago}");
#endregion

#region first or default
//var fodPago = pagosEmpleados.FirstOrDefault(p => p.Monto < 500);
//Console.WriteLine($"Primer pago o por defecto: {fodPago}");
#endregion

#region single
//var sPago = pagosEmpleados.Single(p => p.Monto == 15000.95f);
//Console.WriteLine($"Pago igual a 15000.95f : {sPago}");
#endregion

#region single or default
//var sodPago = pagosEmpleados.SingleOrDefault(p => p.Monto == 15555);
//Console.WriteLine($"Pago igual a 15555 o por defecto: {sodPago}");
#endregion

#region element
//var ePago = pagosEmpleados.ElementAt(0);
//Console.WriteLine($"Pago en posición 0: {ePago}");
#endregion

#region element or default
//var eaodPago = pagosEmpleados.ElementAtOrDefault(10);
//Console.WriteLine($"Pago o por defecto en posición 10: {eaodPago}");
#endregion

#endregion

#region Operadores de union

#region join
//var empleadosPagos = listaEmpleados
//                        .Join(listaPagos,
//                            emp => emp.IdExterno,
//                            pago => pago.IdExternoEmpleado,
//                            (emp, pago) => new
//                            {
//                                emp.Nombre,
//                                pago.Monto
//                            });
//foreach (var empleadoPago in empleadosPagos)
//{
//    Console.WriteLine($"{empleadoPago.Nombre} - {empleadoPago.Monto}");
//}
#endregion

#region group join
//var empleadosPagosGrupo = listaEmpleados
//                            .GroupJoin(listaPagos,
//                                emp => emp.IdExterno,
//                                pago => pago.IdExternoEmpleado,
//                                (emp, pago) => new
//                                {
//                                    Empleado = emp.Nombre,
//                                    PagosAgregados = pago
//                                });

//foreach (var e in empleadosPagosGrupo)
//{
//    if (e.PagosAgregados.Count() > 0)
//        Console.WriteLine(e.Empleado);
//    foreach (var p in e.PagosAgregados)
//        Console.WriteLine(p.Monto);
//}
#endregion

#endregion

#endregion