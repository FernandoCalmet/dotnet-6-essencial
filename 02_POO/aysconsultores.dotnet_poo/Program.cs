Console.WriteLine("Hello World!");

#region Clases y Constructores
//public class Empleado
//{
//    private string _nombre;
//    private string _apellido;

//    public Empleado()
//    {
//        _nombre = string.Empty;
//        _apellido = string.Empty;
//    }

//    public Empleado(string nombre, string apellido)
//    {
//        _nombre = nombre;
//        _apellido = apellido;
//    }

//    public string ObtenerNombres()
//    {
//        return _nombre + " " + _apellido;
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Empleado empleado1 = new Empleado();
//        Console.WriteLine(empleado1.ObtenerNombres());

//        Empleado empleado2 = new Empleado("Fernando", "Calmet");
//        Console.WriteLine(empleado2.ObtenerNombres());
//    }
//}
#endregion

#region Propiedades
//public class Empleado
//{
//    private string _nombre;
//    private string _apellido;

//    public string Nombre
//    {
//        get { return _nombre; }
//        set { _nombre = value; }
//    }

//    public string Apellido
//    {
//        get { return _apellido; }
//        set { _apellido = value; }
//    }

//    public Empleado(string nombre, string apellido)
//    {
//        _nombre = nombre;
//        _apellido = apellido;
//    }

//    public string ObtenerNombres()
//    {
//        return _nombre + " " + _apellido;
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Empleado empleado = new Empleado("Fernando", "Calmet");

//        string nombre = empleado.Nombre; //llamada al bloque get de la propiedad nombre
//        string apellido = empleado.Apellido; //llamada al bloque get de la propiedad apellido

//        empleado.Nombre = "Andrés"; //llamada al bloque set de la propiedad nombre
//        empleado.Apellido = "Ramírez"; //llamada al bloque set de la propiedad apellido

//        Console.WriteLine(empleado.ObtenerNombres());
//    }
//}
#endregion

#region Tipos anónimos y que aceptan valores NULL

#region Clases anónimas
//var miObjetoAnonimo = new { Nombre = "Fernando", Edad = 32 };
//Console.WriteLine($"Mi nombre es {miObjetoAnonimo.Nombre} y tengo {miObjetoAnonimo.Edad} años.");

//var numero = 50;
//var palabra = "Hola";
//var dinero = 2000.30;
//var verdadero = true;
//Console.WriteLine($"El número es {numero}, la palabra es {palabra}, el dinero es {dinero} y la verdad es {verdadero}.");
#endregion

#region Tipos que aceptan valores NULL
//int? numero = null;
//int otroNumero = 200;

//numero = 350;
//numero = otroNumero;

//otroNumero = numero; //Aqui ocurre un problema

//if (numero.HasValue)
//{
//    Console.WriteLine($"El número es {numero}");
//}
//else
//{
//    Console.WriteLine("El número no tiene valor");
//}
#endregion

#endregion

#region Estructuras

#region Ejemplo de una estructura
//public struct Tiempo
//{
//    private int _horas, _minutos, _segundos;

//    public Tiempo(int horas, int minutos, int segundos)
//    {
//        _horas = horas;
//        _minutos = minutos;
//        _segundos = segundos;
//    }

//    public void MostrarTiempo()
//    {
//        Console.WriteLine($"Horas: {_horas}, Minutos: {_minutos}, Segundos: {_segundos}");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Tiempo tiempo = new Tiempo(10, 25, 50);
//        tiempo.MostrarTiempo();

//        Console.ReadKey();
//    }
//}
#endregion

#region Estructura vs Clase
//class/*struct*/ Numero
//{
//    public int Valor { get; set; }

//    public Numero(int number)
//    {
//        Valor = number;
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        Numero numero = new Numero(20);
//        Console.WriteLine(numero.Valor);

//        CambiarNumero(numero);
//        Console.WriteLine(numero.Valor);
//    }

//    public static void CambiarNumero(Numero numero)
//    {
//        numero.Valor = 45;
//    }
//}
#endregion

#endregion

#region Enumeraciones

#region Trabajar con enumeraciones
//public enum DiasDeLaSemana
//{
//    Lunes,
//    Martes,
//    Miercoles,
//    Jueves,
//    Viernes,
//    Sabado,
//    Domingo
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        DiasDeLaSemana sabado = DiasDeLaSemana.Sabado;

//        Console.WriteLine(sabado);      
//        Console.ReadKey();
//    }
//}
#endregion

#region Elegir valores literales de enumeración
//public enum DiasDeLaSemana
//{
//    Lunes = 1,
//    Martes,
//    Miercoles,
//    Jueves,
//    Viernes,
//    Sabado,
//    Domingo
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        DiasDeLaSemana domingo = DiasDeLaSemana.Domingo;

//        Console.WriteLine((int)domingo);
//        Console.ReadKey();
//    }
//}
#endregion

#endregion

#region Herencia

#region Usando herencia
//public class Writer
//{
//    public void Write()
//    {
//        Console.WriteLine("Escribir en un archivo");
//    }
//}
//public class XMLWriter : Writer
//{
//    public void FormatXMLFile()
//    {
//        Console.WriteLine("Formatear archivo XML");
//    }
//}
//public class JSONWriter : Writer
//{
//    public void FormatJSONFile()
//    {
//        Console.WriteLine("Formateo de archivo JSON");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        XMLWriter xmlWriter = new XMLWriter();
//        xmlWriter.FormatXMLFile();
//        xmlWriter.Write();

//        JSONWriter jsonWriter = new JSONWriter();
//        jsonWriter.FormatJSONFile();
//        jsonWriter.Write();
//    }
//}
#endregion

#region Llamar a constructores desde la clase base
//public class Writer
//{
//    public string NombreArchivo { get; set; }

//    public Writer(string nombreArchivo)
//    {
//        NombreArchivo = nombreArchivo;
//    }

//    public void Escribir()
//    {
//        Console.WriteLine("Escribir en un archivo");
//    }
//}
//public class XMLWriter : Writer
//{
//    public XMLWriter(string nombreArchivo)
//        : base(nombreArchivo)
//    {
//    }

//    public void FormatearArchivoXML()
//    {
//        Console.WriteLine("Formatear archivo XML");
//    }
//}

//public class JSONWriter : Writer
//{
//    public JSONWriter(string nombreArchivo)
//        : base(nombreArchivo)
//    {
//    }

//    public void FormatearArchivoJSON()
//    {
//        Console.WriteLine("Formatear archivo JSON");
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        XMLWriter xmlWriter = new XMLWriter("nombreArchivoXML");
//        xmlWriter.FormatearArchivoXML();
//        xmlWriter.Escribir();
//        Console.WriteLine(xmlWriter.NombreArchivo);

//        JSONWriter jsonWriter = new JSONWriter("nombreArchivoJSON");
//        jsonWriter.FormatearArchivoJSON();
//        jsonWriter.Escribir();
//        Console.WriteLine(jsonWriter.NombreArchivo);
//    }
//}
#endregion

#region Usando la nueva palabra clave
//public class Writer
//{
//    public string NombreArchivo { get; set; }

//    public Writer(string nombreArchivo)
//    {
//        NombreArchivo = nombreArchivo;
//    }

//    public void Escribir()
//    {
//        Console.WriteLine("Escribiendo en un archivo");
//    }

//    public void SetNombre()
//    {
//        Console.WriteLine("Configuración del nombre en la clase base Writer");
//    }
//}

//public class XMLWriter : Writer
//{
//    public XMLWriter(string nombreArchivo)
//        : base(nombreArchivo)
//    {
//    }

//    public void FormatearArchivoXML()
//    {
//        Console.WriteLine("Formatear archivo XML");
//    }

//    public new void SetNombre()
//    {
//        Console.WriteLine("Configuración de nombre en la clase XMLWriter");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        XMLWriter xmlWriter = new XMLWriter("nombreArchivoXML");
//        xmlWriter.FormatearArchivoXML();
//        xmlWriter.Escribir();
//        xmlWriter.SetNombre();
//        Console.WriteLine(xmlWriter.NombreArchivo);

//        Console.ReadKey();
//    }
//}
#endregion

#region Declarar métodos con la palabra clave virtual
//public class Writer
//{
//    public string NombreArchivo { get; set; }

//    public Writer(string nombreArchivo)
//    {
//        NombreArchivo = nombreArchivo;
//    }

//    public void Escribir()
//    {
//        Console.WriteLine("Escribir en un archivo");
//    }

//    public void SetNombre()
//    {
//        Console.WriteLine("Configuración del nombre en la clase base Writer");
//    }

//    public virtual void CalcularTamanoArchivo()
//    {
//        Console.WriteLine("Cálculo del tamaño del archivo en una clase Writer");
//    }
//}

//public class XMLWriter : Writer
//{
//    public XMLWriter(string fileName)
//        : base(fileName)
//    {
//    }

//    public void FormatearArchivoXML()
//    {
//        Console.WriteLine("Formatear archivo XML");
//    }

//    public new void SetNombre()
//    {
//        Console.WriteLine("Configuración de nombre en la clase XMLWriter");
//    }

//    public override void CalcularTamanoArchivo()
//    {
//        base.CalcularTamanoArchivo();
//        Console.WriteLine("Cálculo del tamaño del archivo en la clase XMLWriter");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Writer writer = new Writer("nombreArchivo");
//        writer.Escribir();
//        writer.SetNombre();
//        writer.CalcularTamanoArchivo();

//        XMLWriter xmlWriter = new XMLWriter("nombreArchivoXML");
//        xmlWriter.FormatearArchivoXML();
//        xmlWriter.Escribir();
//        xmlWriter.SetNombre();
//        xmlWriter.CalcularTamanoArchivo();

//        Console.ReadKey();
//    }
//}
#endregion

#endregion

#region Interfaces

#region Implementar una interfaz
//public interface IWriter
//{
//    void EscribirArchivo();
//}

//public class XmlWritter : IWriter
//{
//    public void EscribirArchivo()
//    {
//        Console.WriteLine("Escritura de archivo en la clase XmlWriter.");
//    }
//}

//public class JsonWriter : IWriter
//{
//    public void EscribirArchivo()
//    {
//        Console.WriteLine("Escritura de archivo en la clase JsonWritter.");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        IWriter writer = new XmlWritter();
//        writer.EscribirArchivo();

//        writer = new JsonWriter();
//        writer.EscribirArchivo();

//        Console.ReadKey();
//    }
//}
#endregion

#region Implementar una interfaz y una clase base
//public interface IWriter
//{
//    void EscribirArchivo();
//}

//public class FileBase
//{
//    public virtual void SetNombre()
//    {
//        Console.WriteLine("Nombre de la configuración en la clase base Writer.");
//    }
//}

//public class XmlWritter : FileBase, IWriter
//{
//    public void EscribirArchivo()
//    {
//        Console.WriteLine("Escritura de archivo en la clase XmlWriter.");
//    }

//    public override void SetNombre()
//    {
//        Console.WriteLine("Nombre de configuración en la clase XmlWriter.");
//    }
//}

//public class JsonWriter : FileBase, IWriter
//{
//    public void EscribirArchivo()
//    {
//        Console.WriteLine("Escritura de archivo en la clase JsonWritter.");
//    }

//    public override void SetNombre()
//    {
//        Console.WriteLine("Configuración de nombre en la clase JsonWriter.");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        XmlWritter xmlWriter = new XmlWritter();
//        xmlWriter.EscribirArchivo();
//        xmlWriter.SetNombre();

//        IWriter writer = new XmlWritter();        
//        writer.EscribirArchivo();
//        //writer.SetNombre();

//        writer = new JsonWriter();
//        writer.EscribirArchivo();
//        //writer.SetNombre();

//        Console.ReadKey();
//    }
//}
#endregion

#region Trabajar con múltiples interfaces
//public interface IFormatter
//{
//    void FormatearArchivo();
//}

//public interface IWriter
//{
//    void EscribirArchivo();
//}

//public class FileBase
//{
//    public virtual void SetNombre()
//    {
//        Console.WriteLine("Setting name in the base Writer class.");
//    }
//}


//public class XmlWriter : FileBase, IWriter, IFormatter
//{
//    public void EscribirArchivo()
//    {
//        Console.WriteLine("Writing file in the XmlWriter class.");
//    }

//    public override void SetNombre()
//    {
//        Console.WriteLine("Setting name in the XmlWriter class.");
//    }

//    public void FormatearArchivo()
//    {
//        Console.WriteLine("Formatting file in XmlWriter class.");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        XmlWriter xmlWriter = new XmlWriter();
//        xmlWriter.EscribirArchivo();
//        xmlWriter.SetNombre();
//        xmlWriter.FormatearArchivo();

//        IWriter writer = new XmlWriter();
//        writer.EscribirArchivo();
//        //writer.SetNombre();

//        Console.ReadKey();
//    }
//}
#endregion

#endregion

#region Clases abstractas
//public abstract class Writer
//{
//    public abstract void Escribir();

//    public virtual void SetNombre()
//    {
//        Console.WriteLine("Configuración del nombre en la clase base Writer");
//    }

//    public abstract void CalcularTamanoArchivo();
//}

//public class WriterCalculator : Writer
//{
//    public override void CalcularTamanoArchivo()
//    {
//        Console.WriteLine("Calculando el tamaño del archivo en la clase WriterCalculator");
//    }

//    public override void Escribir()
//    {
//        Console.WriteLine("Escribiendo en la clase WriterCalculator");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Writer writer = new WriterCalculator();
//        writer.Escribir();
//        writer.SetNombre();
//        writer.CalcularTamanoArchivo();

//        Console.ReadKey();
//    }
//}
#endregion

#region Genéricos

#region Tipo genérico T
//public class InicializadorColeccion<T>
//{
//    private T[] coleccion;

//    public InicializadorColeccion(int longitudColeccion)
//    {
//        coleccion = new T[longitudColeccion];
//    }

//    public void AgregarElementosAColeccion(params T[] elementos)
//    {
//        for (int i = 0; i < elementos.Length; i++)
//        {
//            coleccion[i] = elementos[i];
//        }
//    }

//    public T[] RecuperarTodosElementos()
//    {
//        return coleccion;
//    }

//    public T RecuperarElementoEnIndice(int indice)
//    {
//        return coleccion[indice];
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        InicializadorColeccion<int> inicializador = new InicializadorColeccion<int>(5);

//        inicializador.AgregarElementosAColeccion(5, 8, 12, 74, 13);
//        int[] coleccion = inicializador.RecuperarTodosElementos();
//        int numero = inicializador.RecuperarElementoEnIndice(3);

//        foreach (int elemento in coleccion)
//        {
//            Console.WriteLine(elemento);
//        }

//        Console.WriteLine();
//        Console.WriteLine($"El elemento en el índice seleccionado es: {numero}");

//        Console.ReadKey();
//    }
//}
#endregion

#region Restricciones con genéricos
//public class Persona
//{
//    public string Nombre { get; set; }
//    public string Apellido { get; set; }
//    public int Edad { get; set; }
//}

//public interface IOperacionesGenericas<Entity> where Entity : class
//{
//    int Agregar(Entity entity);
//    int Editar(Entity entity);
//    int Eliminar(Entity entity);
//}

//public interface IOperaciones : IOperacionesGenericas<Persona>
//{
//    int Agregar(Persona persona);
//    int Editar(Persona persona);
//    int Eliminar(Persona persona);
//}

//public class Operaciones : IOperaciones
//{
//    public int Agregar(Persona persona)
//    {
//        Console.WriteLine($"Se agregó la persona {persona.Nombre} {persona.Apellido}");
//        return 1;
//    }

//    public int Editar(Persona persona)
//    {
//        Console.WriteLine($"Se editó la persona {persona.Nombre} {persona.Apellido}");
//        return 1;
//    }

//    public int Eliminar(Persona persona)
//    {
//        Console.WriteLine($"Se eliminó la persona {persona.Nombre} {persona.Apellido}");
//        return 1;
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        IOperaciones operaciones = new Operaciones();
//        Persona persona = new Persona();
//        persona.Nombre = "Fernando";
//        persona.Apellido = "Calmet";
//        persona.Edad = 23;

//        Console.WriteLine(operaciones.Agregar(persona));
//        Console.WriteLine(operaciones.Editar(persona));
//        Console.WriteLine(operaciones.Eliminar(persona));

//        Console.ReadKey();
//    }
//}
#endregion

#endregion