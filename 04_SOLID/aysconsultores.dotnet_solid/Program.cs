#region Principio de Responsabilidad Unica
//using aysconsultores.dotnet_solid._1_Responsabilidad_Unica;

#region Sin aplicar principio
//using aysconsultores.dotnet_solid._1_Responsabilidad_Unica.SinAplicarPrincipio;

//var informe = new InformeTrabajo();
//informe.AgregarEntrada(
//    new EntradaInformeTrabajo
//    {
//        CodigoProyecto = "P1",
//        NombreProyecto = "Proyecto 1",
//        HorasDeTrabajo = 100
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
//        CodigoProyecto = "P1",
//        NombreProyecto = "Proyecto 1",
//        HorasDeTrabajo = 100
//    });
//Console.WriteLine(informe.ToString());

//var guardado = new GuardadoArchivo();
//guardado.GuardarArchivo(@"Informes", "InformeTrabajo.txt", informe);

#endregion

#region Solución Mejorada
//using aysconsultores.dotnet_solid._1_Responsabilidad_Unica.SolucionMejorada;

//var informe = new InformeTrabajo();
//informe.AgregarEntrada(
//    new EntradaInformeTrabajo
//    {
//        CodigoProyecto = "P1",
//        NombreProyecto = "Proyecto 1",
//        HorasDeTrabajo = 100
//    });
//informe.AgregarEntrada(
//    new EntradaInformeTrabajo
//    {
//        CodigoProyecto = "P2",
//        NombreProyecto = "Proyecto 2",
//        HorasDeTrabajo = 150
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

#endregion

#region Aplicando principio

#endregion

#endregion

#region Principio de Segregación de Interfaces

#region Sin aplicar principio

#endregion

#region Aplicando principio

#endregion

#endregion

#region Principio de Inversión de Dependencias

#region Sin aplicar principio

#endregion

#region Aplicando principio

#endregion

#endregion