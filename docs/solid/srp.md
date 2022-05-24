[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# PRINCIPIO DE RESPONSABILIDAD ÚNICA

El Principio de Responsabilidad Única establece que nuestras clases deben tener una sola razón para cambiar o, en otras palabras, debe tener una sola responsabilidad.

## Creación del proyecto inicial

Vamos a empezar con una sencilla aplicación de consola.

Imagínese si tenemos una tarea para crear una función de informe de trabajo que, una vez creada, se puede guardar en un archivo y tal vez cargar en la nube o usar para algún otro propósito.

Así que vamos a comenzar con una clase de modelo simple:

```csharp
public class EntradaInformeTrabajo
{
    public string CodigoProyecto { get; set; }
    public string NombreProyecto { get; set; }
    public int HorasDeTrabajo { get; set; }
}
```

El siguiente paso es crear una clase `InformeTrabajo` que manejará todas las características requeridas para nuestro proyecto:

```csharp
public class InformeTrabajo
{
    private readonly List<EntradaInformeTrabajo> _entradas;
    public InformeTrabajo()
    {
        _entradas = new List<EntradaInformeTrabajo>();
    }
    public void AgregarEntrada(EntradaInformeTrabajo entrada) => _entradas.Add(entrada);
    public void RemoverEntradaPorIndice(int indice) => _entradas.RemoveAt(indice);   
    public override string ToString() =>
        string
            .Join(Environment.NewLine, _entradas.Select(x => $"Codigo: {x.CodigoProyecto}, Nombre: {x.NombreProyecto}, Horas: {x.HorasDeTrabajo}"));
}
```

En esta clase, hacemos un seguimiento de las entradas de nuestro informe de trabajo al agregarlas y eliminarlas de una lista. Además, solo estamos anulando el método `ToString()` para ajustarlo a nuestros requisitos.

Debido a que tenemos nuestra clase `InformeTrabajo`, está bastante bien agregarle nuestras características adicionales, como guardar en un archivo:

```csharp
public class InformeTrabajo
{
    private readonly List<EntradaInformeTrabajo> _entradas;
    public InformeTrabajo()
    {
        _entradas = new List<EntradaInformeTrabajo>();
    }
    public void AgregarEntrada(EntradaInformeTrabajo entrada) => _entradas.Add(entrada);
    public void RemoverEntradaPorIndice(int indice) => _entradas.RemoveAt(indice);
    public void GuardarArchivo(string rutaDirectorio, string nombreArchivo)
    {
        if (!Directory.Exists(rutaDirectorio))
        {
            Directory.CreateDirectory(rutaDirectorio);
        }

        File.WriteAllText(Path.Combine(rutaDirectorio, nombreArchivo), ToString());
    }

    public override string ToString() =>
        string
            .Join(Environment.NewLine, _entradas.Select(x => $"Codigo: {x.CodigoProyecto}, Nombre: {x.NombreProyecto}, Horas: {x.HorasDeTrabajo}"));
}
```

```csharp
class Program
{
    static void Main(string[] args)
    {
        var informe = new InformeTrabajo();
        informe.AgregarEntrada(
            new EntradaInformeTrabajo
            {
                CodigoProyecto = "P1",
                NombreProyecto = "Proyecto 1",
                HorasDeTrabajo = 100
            });
        informe.AgregarEntrada(
            new EntradaInformeTrabajo
            {
                CodigoProyecto = "P2",
                NombreProyecto = "Proyecto 2",
                HorasDeTrabajo = 200
            });
        informe.GuardarArchivo(@"Informes", "InformeTrabajo.txt");
        Console.WriteLine(informe.ToString());
    }
}
```

## Problemas con este código

Podemos agregar aún más funciones en esta clase, como los métodos `Cargar` o `CargarNube` porque todos están relacionados con nuestro `InformeTrabajo`, pero el hecho de que podamos no significa que tengamos que hacerlo.

En este momento, hay un problema con la clase `InformeTrabajo`.

**Tiene más de una responsabilidad.**

Su trabajo no es solo realizar un seguimiento de las entradas de nuestro informe de trabajo, sino también guardar todo el informe de trabajo en un archivo. Esto significa que estamos violando el `SRP` y nuestra clase tiene más de una razón para cambiar en el futuro.

La primera razón para cambiar esta clase es si queremos modificar la forma en que hacemos un seguimiento de nuestras entradas. Pero si queremos guardar un archivo de una manera diferente, esa es una razón completamente nueva para cambiar nuestra clase. E imagine cómo se vería esta clase si le agregáramos funcionalidades adicionales. Tendríamos tantas partes de código no relacionadas en una sola clase.

Entonces, para evitar eso, refactoricemos el código.

## Refactorización hacia SRP

Lo primero que tenemos que hacer es separar la parte de nuestro código que es diferente a los demás. En nuestro caso, ese es obviamente el método `GuardarArchivo`, por lo que lo moveremos a otra clase que sea más apropiada:

```csharp
public class GuardadoArchivo
{
    public void GuardarArchivo(string rutaDirectorio, string nombreArchivo, InformeTrabajo informe)
    {
        if (!Directory.Exists(rutaDirectorio))
        {
            Directory.CreateDirectory(rutaDirectorio);
        }

        File.WriteAllText(Path.Combine(rutaDirectorio, nombreArchivo), informe.ToString());
    }
}
```

```csharp
public class InformeTrabajo
{
    private readonly List<EntradaInformeTrabajo> _entradas;
    public InformeTrabajo()
    {
        _entradas = new List<EntradaInformeTrabajo>();
    }
    public void AgregarEntrada(EntradaInformeTrabajo entrada) => _entradas.Add(entrada);
    public void RemoverEntradaPorIndice(int indice) => _entradas.RemoveAt(indice);

    public override string ToString() =>
        string
            .Join(Environment.NewLine, _entradas.Select(x => $"Codigo: {x.CodigoProyecto}, Nombre: {x.NombreProyecto}, Horas: {x.HorasDeTrabajo}"));
}
```

En este caso, hemos separado nuestras responsabilidades en dos clases. La clase `InformeTrabajo` ahora es responsable de realizar un seguimiento de las entradas del informe de trabajo y la clase `GuardarArchivo` es responsable de guardar un archivo.

Habiendo hecho esto, hemos separado las preocupaciones de cada clase, haciéndolas también más legibles y fáciles de mantener. Como resultado, si queremos cambiar la forma en que guardamos un archivo, solo tenemos una razón para hacerlo y un lugar para hacerlo, que es la clase `GuardarArchivo`.

Podemos comprobar que todo funciona como se supone que debe hacerlo:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var informe = new InformeTrabajo();
        informe.AgregarEntrada(
            new EntradaInformeTrabajo
            {
                CodigoProyecto = "PYC1",
                NombreProyecto = "Proyecto 1",
                HorasDeTrabajo = 100
            });
        informe.AgregarEntrada(
            new EntradaInformeTrabajo
            {
                CodigoProyecto = "PYC2",
                NombreProyecto = "Proyecto 2",
                HorasDeTrabajo = 200
            });
                
        var guardado = new GuardadoArchivo();
        guardado.GuardarArchivo(@"Informes", "InformeTrabajo.txt", informe);
        Console.WriteLine(informe.ToString());
    }
}
```

## Hacer el código aún mejor

Si observamos nuestro método `GuardarArchivo`, vemos que hace su trabajo, que es guardar un informe de trabajo en un archivo, pero ¿puede hacerlo aún mejor? Este método está estrechamente relacionado con la clase `InformeTrabajo`, pero ¿qué pasa si queremos crear una clase `Programadora` que realice un seguimiento de sus tareas programadas? Todavía nos gustaría guardarlo en un archivo.

Bueno, en ese caso, vamos a crear algunos cambios en nuestro código:

```csharp
public interface IGestorEntrada<T>
{
    void AgregarEntrada(T entrada);
    void RemoverEntradaPorIndice(int indice);
}
```

El único cambio en la clase `InformeTrabajo` es implementar esta interfaz:

```csharp
public class InformeTrabajo : IGestorEntrada<EntradaInformeTrabajo>
```

Finalmente, tenemos que cambiar la firma del método `GuardarArchivo`:

```csharp
public void GuardarArchivo<T>(string rutaDirectorio, string nombreArchivo, IGestorEntrada<T> informe)
```

Después de estas modificaciones, vamos a tener el mismo resultado, pero ahora si tenemos una tarea para implementar `Programadora`, será bastante simple implementar eso:

```csharp
public class TareaProgramada
{
    public int TareaId { get; set; }
    public string Contenido { get; set; }
    public DateTime EjecutarEn { get; set; }
}
```

```csharp
public class Programadora : IGestorEntrada<TareaProgramada>
{
    private readonly List<TareaProgramada> _tareasProgramadas;
    public Programadora()
    {
        _tareasProgramadas = new List<TareaProgramada>();
    }
    public void AgregarEntrada(TareaProgramada entrada) => _tareasProgramadas.Add(entrada);
    public void RemoverEntradaPorIndice(int indice) => _tareasProgramadas.RemoveAt(indice);
    public override string ToString() =>
        string.Join(Environment.NewLine, _tareasProgramadas.Select(x => $"Id: {x.TareaId}, Contenido: {x.Contenido}, Ejecución: {x.EjecutarEn}"));
}
```

```csharp
class Program
{
    static void Main(string[] args)
    {
        var informe = new InformeTrabajo();
        informe.AgregarEntrada(
            new EntradaInformeTrabajo
            {
                CodigoProyecto = "PYC1",
                NombreProyecto = "Proyecto 1",
                HorasDeTrabajo = 100
            });
        informe.AgregarEntrada(
            new EntradaInformeTrabajo
            {
                CodigoProyecto = "PYC2",
                NombreProyecto = "Proyecto 2",
                HorasDeTrabajo = 200
            });

        var programadora = new Programadora();
        programadora.AgregarEntrada(
            new TareaProgramada
            {
                TareaId = 1,
                Contenido = "Tarea 1",
                EjecutarEn = DateTime.Now.AddDays(1)
            });
        programadora.AgregarEntrada(
            new TareaProgramada
            {
                TareaId = 2,
                Contenido = "Tarea 2",
                EjecutarEn = DateTime.Now.AddDays(2)
            });

        Console.WriteLine(informe.ToString());
        Console.WriteLine(programadora.ToString());

        var guardado = new GuardadoArchivo();
        guardado.GuardarArchivo(@"Informes", "InformeTrabajo.txt", informe);
        guardado.GuardarArchivo(@"Programacion", "Programacion.txt", programadora);
    }
}
```

Después de ejecutar este código, tendremos nuestro archivo guardado en una ubicación requerida en un horario definido.

Vamos a dejarlo así. Ahora cada clase que tenemos es responsable de una cosa y solo de una cosa.

## Beneficios del principio de responsabilidad única

- Nuestro código ha mejorado de varias maneras al implementar SRP. El primero es que se ha vuelto menos complejo. Debido a que estamos tratando de realizar solo una tarea en nuestra clase, se han vuelto libres de desorden y fáciles de leer. A medida que reducimos la complejidad del código, nuestro código se vuelve legible y, por lo tanto, mantenible.

- Como pudimos ver en nuestro ejemplo, si nuestra clase hace bien su trabajo, podemos reutilizar su lógica en un proyecto. Además, con dicho código, las pruebas también se vuelven más fáciles.

- Cuando implementamos SRP en nuestro código, nuestros métodos se vuelven altamente relacionados (coherentes). Significa que se unen diferentes métodos para hacer una cosa y hacerlo bien.

- Finalmente, nuestras clases son menos dependientes entre sí (desacopladas), lo cual es una de las cosas más importantes que se deben lograr mientras se trabaja en un proyecto.

## Desventajas potenciales de SRP

- No existe una regla estricta que establezca cuál es esa "razón única para cambiar" en nuestra clase. Cada uno interpreta esto subjetivamente o más bien como siente que debería implementarse. Las reglas no son claras sobre dónde debemos trazar la línea, por lo que potencialmente podemos encontrar diferentes "formas correctas" de implementar la misma característica.

- Pero aún así, la conclusión es que no importa lo que alguien piense sobre cuál es la razón para cambiar, todos debemos esforzarnos por escribir un código legible y mantenible, implementando así el Principio de Responsabilidad Única a nuestra manera.

- Una de las posibles desventajas es que en proyectos que ya están escritos, es difícil implementar SRP. No decimos que no sea posible, solo que llevará más tiempo y requerirá más recursos también.

- La implementación de SRP también conduce a la escritura de clases compactas con métodos pequeños. Y a primera vista, esto se ve genial. Pero tener una clase grande descompuesta en muchas clases pequeñas crea un riesgo organizacional. Si esas clases no están bien organizadas y agrupadas, en realidad podría aumentar la cantidad de trabajo necesario para cambiar un sistema y comprenderlo, lo cual es lo contrario de lo que queríamos lograr en primer lugar.

---
[Regresar al menú principal](https://github.com/FernandoCalmet/dotnet-6-essencial)

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet