#region Principio de Responsabilidad Unica
//using aysconsultores.dotnet_solid._1_Responsabilidad_Unica;

#region Sin aplicar principio
//using aysconsultores.dotnet_solid._1_Responsabilidad_Unica.SinAplicarPrincipio;

//var informe = new InformeTrabajo();
//informe.AgregarEntrada(
//    new EntradaInformeTrabajo
//    {
//        CodigoProyecto = "PYC1",
//        NombreProyecto = "Proyecto 1",
//        HorasDeTrabajo = 100
//    });
//informe.AgregarEntrada(
//    new EntradaInformeTrabajo
//    {
//        CodigoProyecto = "PYC2",
//        NombreProyecto = "Proyecto 2",
//        HorasDeTrabajo = 200
//    });
//informe.GuardarArchivo(@"Informes", "InformeTrabajo.txt");
//Console.WriteLine(informe.ToString());
#endregion

#region Aplicando principio
//using aysconsultores.dotnet_solid._1_Responsabilidad_Unica.AplicandoPrincipio;

//var informe = new InformeTrabajo();
//informe.AgregarEntrada(
//    new EntradaInformeTrabajo
//    {
//        CodigoProyecto = "PYC1",
//        NombreProyecto = "Proyecto 1",
//        HorasDeTrabajo = 100
//    });
//informe.AgregarEntrada(
//    new EntradaInformeTrabajo
//    {
//        CodigoProyecto = "PYC2",
//        NombreProyecto = "Proyecto 2",
//        HorasDeTrabajo = 200
//    });

//var guardado = new GuardadoArchivo();
//guardado.GuardarArchivo(@"Informes", "InformeTrabajo.txt", informe);
//Console.WriteLine(informe.ToString());
#endregion

#region Solución Mejorada
//using aysconsultores.dotnet_solid._1_Responsabilidad_Unica.SolucionMejorada;

//var informe = new InformeTrabajo();
//informe.AgregarEntrada(
//    new EntradaInformeTrabajo
//    {
//        CodigoProyecto = "PYC1",
//        NombreProyecto = "Proyecto 1",
//        HorasDeTrabajo = 100
//    });
//informe.AgregarEntrada(
//    new EntradaInformeTrabajo
//    {
//        CodigoProyecto = "PYC2",
//        NombreProyecto = "Proyecto 2",
//        HorasDeTrabajo = 200
//    });

//var programadora = new Programadora();
//programadora.AgregarEntrada(
//    new TareaProgramada
//    {
//        TareaId = 1,
//        Contenido = "Tarea 1",
//        EjecutarEn = DateTime.Now.AddDays(1)
//    });
//programadora.AgregarEntrada(
//    new TareaProgramada
//    {
//        TareaId = 2,
//        Contenido = "Tarea 2",
//        EjecutarEn = DateTime.Now.AddDays(2)
//    });

//Console.WriteLine(informe.ToString());
//Console.WriteLine(programadora.ToString());

//var guardado = new GuardadoArchivo();
//guardado.GuardarArchivo(@"Informes", "InformeTrabajo.txt", informe);
//guardado.GuardarArchivo(@"Programacion", "Programacion.txt", programadora);
#endregion

#endregion

#region Principio de Abierto y Cerrado
//using aysconsultores.dotnet_solid._2_Abierto_Cerrado;

#region Sin aplicar principio
//using aysconsultores.dotnet_solid._2_Abierto_Cerrado.SinAplicarPrincipio;

//var informesDesarrolladores = new List<InformeDesarrollador>
//{
//    new InformeDesarrollador {Id = 1, Nombre = "Dev1", Nivel = "Senior developer", TarifaPorHora  = 30.5, HorasTrabajando = 160 },
//    new InformeDesarrollador {Id = 2, Nombre = "Dev2", Nivel = "Junior developer", TarifaPorHora  = 20, HorasTrabajando = 150 },
//    new InformeDesarrollador {Id = 3, Nombre = "Dev3", Nivel = "Senior developer", TarifaPorHora  = 30.5, HorasTrabajando = 180 }
//};
//var calculadora = new CalculadoraSalario(informesDesarrolladores);
//Console.WriteLine($"La suma de todos los salarios de los desarrolladores es {calculadora.CalcularSalarioTotal()} dolares");
#endregion

#region Aplicando principio
//using aysconsultores.dotnet_solid._2_Abierto_Cerrado.AplicandoPrincipio;

//var informesDesarrolladores = new List<CalculadoraSalarioBase>
//{
//    new CalculadoraSalarioSenior(new InformeDesarrollador {Id = 1, Nombre = "Dev1", Nivel = "Senior developer", TarifaPorHora  = 30.5, HorasTrabajando = 160 }),
//    new CalculadoraSalarioJunior(new InformeDesarrollador {Id = 2, Nombre = "Dev2", Nivel = "Junior developer", TarifaPorHora  = 20, HorasTrabajando = 150 }),
//    new CalculadoraSalarioSenior(new InformeDesarrollador {Id = 3, Nombre = "Dev3", Nivel = "Senior developer", TarifaPorHora  = 30.5, HorasTrabajando = 180 })
//};
//var calculadora = new CalculadoraSalario(informesDesarrolladores);
//Console.WriteLine($"La suma de todos los salarios de los desarrolladores es {calculadora.CalcularSalarioTotal()} dolares");
#endregion

#endregion

#region Principio de Sustitución de Liskov

#region Sin aplicar principio
//using aysconsultores.dotnet_solid._3_Sustitucion_Liskov.SinAplicarPrincipio;

//var numeros = new int[] { 5, 7, 9, 8, 1, 6, 4 };
//CalculadoraSumas suma = new CalculadoraSumas(numeros);
//Console.WriteLine($"La suma de todos los números: {suma.Calcular()}");
//CalculadoraSumas sumaPares = new CalculadoraSumaNumerosPares(numeros);
//Console.WriteLine($"La suma de todos los números pares: {sumaPares.Calcular()}");

#endregion

#region Aplicando principio
//using aysconsultores.dotnet_solid._3_Sustitucion_Liskov.AplicandoPrincipio;

//var numeros = new int[] { 5, 7, 9, 8, 1, 6, 4 };
//Calculadora suma = new CalculadoraSumas(numeros);
//Console.WriteLine($"La suma de todos los números: {suma.Calcular()}");
//Console.WriteLine();
//Calculadora sumaPares = new CalculadoraSumaNumerosPares(numeros);
//Console.WriteLine($"La suma de todos los números pares: {sumaPares.Calcular()}");
#endregion

#endregion

#region Principio de Segregación de Interfaces

#region Sin aplicar principio
//using aysconsultores.dotnet_solid._4_Segregacion_Interfaces.SinAplicarPrincipio;

//IVehiculo automovilMultiFuncional = new AutomovilMultiFuncional();
//automovilMultiFuncional.Conducir();
//automovilMultiFuncional.Volar();

//IVehiculo automovil = new Automovil();
//automovil.Conducir();
//automovil.Volar();//Conflicto en este punto

//IVehiculo aeroplano = new Aeroplano();
//aeroplano.Conducir();//Conflicto en este punto
//aeroplano.Volar();
#endregion

#region Aplicando principio
//using aysconsultores.dotnet_solid._4_Segregacion_Interfaces.AplicandoPrincipio;

//IAutomovil automovil = new Automovil();
//automovil.Conducir();

//IAeroplano aeroplano = new Aeroplano();
//aeroplano.Volar();

//IAutomovilMultiFuncional automovilMultiFuncional = new AutomovilMultiFuncional();
//automovilMultiFuncional.Conducir();
//automovilMultiFuncional.Volar();
#endregion

#endregion

#region Principio de Inversión de Dependencias
//using aysconsultores.dotnet_solid._5_Inversion_Dependencias;

#region Sin aplicar principio
//using aysconsultores.dotnet_solid._5_Inversion_Dependencias.SinAplicarPrincipio;

//Empleado empleado1 = new() { Nombre = "Fernando", Genero = Genero.Masculino, Cargo = Cargo.Administrador };
//Empleado empleado2 = new() { Nombre = "Estefania", Genero = Genero.Femenino, Cargo = Cargo.Gerente };
//Empleado empleado3 = new() { Nombre = "Sofia", Genero = Genero.Femenino, Cargo = Cargo.Gerente };
//Empleado empleado4 = new() { Nombre = "Mario", Genero = Genero.Masculino, Cargo = Cargo.Gerente };

//EmpleadoGerente empleadoGerente = new();
//empleadoGerente.AgregarEmpleado(empleado1);
//empleadoGerente.AgregarEmpleado(empleado2);
//empleadoGerente.AgregarEmpleado(empleado3);
//empleadoGerente.AgregarEmpleado(empleado4);

//EmpleadoEstadisticas empleadoEstadisticas = new(empleadoGerente);
//var resultado = empleadoEstadisticas.ContarGerentesFeminino();
//Console.WriteLine($"El total de gerentes femeninos es: {resultado}");
#endregion

#region Aplicando principio
//using aysconsultores.dotnet_solid._5_Inversion_Dependencias.AplicandoPrincipio;

//EmpleadoGerente empleadoGerente = new();
//empleadoGerente.AgregarEmpleado(new Empleado { Nombre = "Fernando", Genero = Genero.Masculino, Cargo = Cargo.Administrador });
//empleadoGerente.AgregarEmpleado(new Empleado { Nombre = "Estefania", Genero = Genero.Femenino, Cargo = Cargo.Gerente });
//empleadoGerente.AgregarEmpleado(new Empleado { Nombre = "Sofia", Genero = Genero.Femenino, Cargo = Cargo.Gerente });
//empleadoGerente.AgregarEmpleado(new Empleado { Nombre = "Mario", Genero = Genero.Masculino, Cargo = Cargo.Gerente });

//var empleadoEstadisticas = new EmpleadoEstadisticas(empleadoGerente);
//var resultado = empleadoEstadisticas.ContarGerentesFeminino();
//Console.WriteLine($"El total de gerentes femeninos es: {resultado}");
#endregion

#endregion