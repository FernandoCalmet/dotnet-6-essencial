[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# PRINCIPIO DE INVERSIÓN DE DEPENDENCIAS

La idea básica detrás del Principio de inversión de dependencia es que debemos crear los módulos de nivel superior con su lógica compleja de tal manera que sean reutilizables y no se vean afectados por ningún cambio de los módulos de nivel inferior en nuestra aplicación. Para lograr este tipo de comportamiento en nuestras aplicaciones, introducimos la abstracción que desacopla los módulos de nivel superior de los de nivel inferior.

Teniendo esta idea en mente, el Principio de Inversión de Dependencia establece que

- Los módulos de alto nivel no deberían depender de los módulos de bajo nivel, ambos deberían depender de abstracciones.

- Las abstracciones no deben depender de los detalles. Los detalles deben depender de las abstracciones.

## ¿Qué son los módulos de alto y bajo nivel?

Los módulos de alto nivel describen aquellas operaciones en nuestra aplicación que tienen una naturaleza más abstracta y contienen una lógica más compleja. Estos módulos organizan módulos de bajo nivel en nuestra aplicación.

Los módulos de bajo nivel contienen componentes individuales más específicos que se centran en detalles y partes más pequeñas de la aplicación. Estos módulos se utilizan dentro de los módulos de alto nivel en nuestra aplicación.

Lo que debemos entender cuando hablamos de `DIP` y estos módulos es que tanto los módulos de alto nivel como los de bajo nivel dependen de abstracciones. Podemos encontrar diferentes opiniones sobre si el `DIP` invierte o no la dependencia entre módulos de alto y bajo nivel. Algunos están de acuerdo con la primera opinión y otros prefieren la segunda. Pero el terreno común es que el `DIP` crea una estructura desacoplada entre módulos de alto y bajo nivel al introducir abstracción entre ellos.

La inyección de dependencia es una forma de implementar el principio de inversión de dependencia.

## Ejemplo que viola DIP

Comencemos creando dos enumeraciones y una clase modelo:

```csharp
public enum Genero
{
    Masculino,
    Femenino
}
```

```csharp
public enum Cargo
{
    Administrador,
    Gerente,
    Ejecutivo
}
```

```csharp
public class Empleado
{
    public string Nombre { get; set; }
    public Genero Genero { get; set; }
    public Cargo Cargo { get; set; }
}
```

Para continuar, vamos a crear una clase de bajo nivel que realiza un seguimiento (de forma simplificada) de nuestros empleados:

```csharp
public class EmpleadoGerente
{
    private readonly List<Empleado> _empleados;

    public EmpleadoGerente()
    {
        _empleados = new();
    }

    public void AgregarEmpleado(Empleado empleado)
    {
        _empleados.Add(empleado);
    }
}
```

Además, vamos a crear una clase de nivel superior para realizar algún tipo de análisis estadístico de nuestros empleados:

```csharp
public class EmpleadoEstadisticas
{
    private readonly EmpleadoGerente _empleadoGerente;

    public EmpleadoEstadisticas(EmpleadoGerente empleadoGerente)
    {
        _empleadoGerente = empleadoGerente;
    }

    public int ContarGerentesFeminino() =>
        //lógica se aplica aqui
}
```

Con este tipo de estructura en nuestra clase `EmpleadoGerente`, no podemos hacer uso de la lista `_empleados` en la clase `EmpleadoEstadisticas`, por lo que la solución obvia sería exponer esa lista privada:

```csharp
public class EmpleadoGerente
{
    private readonly List<Empleado> _empleados;

    public EmpleadoGerente()
    {
        _empleados = new();
    }

    public void AgregarEmpleado(Empleado empleado)
    {
        _empleados.Add(empleado);
    }

    public List<Empleado> Empleados => _empleados;
}
```

Ahora, podemos completar la lógica del método `Count`:

```csharp
 public class EmpleadoEstadisticas
{
    private readonly EmpleadoGerente _empleadoGerente;

    public EmpleadoEstadisticas(EmpleadoGerente empleadoGerente)
    {
        _empleadoGerente = empleadoGerente;
    }

    public int ContarGerentesFeminino() =>
        _empleadoGerente.Empleados.Count(emp => emp.Genero == Genero.Femenino && emp.Cargo == Cargo.Gerente);
}
 ```
 
Aunque esto funcionará bien, no es lo que consideramos un buen código y viola el `DIP`.

### ¿Como es eso?

Bueno, antes que nada, nuestra clase `EmpleadoEstadisticas` tiene una fuerte relación (acoplada) con la clase `EmpleadoGerente` y no podemos enviar ningún otro objeto en el constructor `EmpleadoEstadisticas` excepto el objeto `EmpleadoGerente`. El segundo problema es que estamos usando la propiedad pública de la clase de bajo nivel dentro de la clase de alto nivel. Al hacerlo, nuestra clase de bajo nivel no puede cambiar su forma de realizar un seguimiento de los empleados. Si queremos cambiar su comportamiento para usar un diccionario en lugar de una lista, debemos cambiar el comportamiento de la clase `EmpleadoEstadisticas` con seguridad. Y eso es algo que queremos evitar en la medida de lo posible.

## Mejorar nuestro código implementando el principio de inversión de dependencia

Lo que queremos es desacoplar nuestras dos clases para que ambas dependan de la abstracción.

Entonces, lo primero que debemos hacer es crear la IEmployeeSearchableinterfaz:

```csharp
public interface IBusquedaEmpleado
{
    IEnumerable<Empleado> ObtenerEmpleadosPorGeneroYCargo(Genero genero, Cargo cargo);
}
```

Entonces, modifiquemos la clase `EmpleadoGerente`:

```csharp
public class EmpleadoGerente : IBusquedaEmpleado
{
    private readonly List<Empleado> _empleados;
    public EmpleadoGerente()
    {
        _empleados = new();
    }
    public void AgregarEmpleado(Empleado empleado) => _empleados.Add(empleado);
    public IEnumerable<Empleado> ObtenerEmpleadosPorGeneroYCargo(Genero genero, Cargo cargo) =>
        _empleados.Where(emp => emp.Genero == genero && emp.Cargo == cargo);
}
```

Finalmente, podemos modificar la EmployeeStatisticsclase:

```csharp
public class EmpleadoEstadisticas
{
    private readonly IBusquedaEmpleado _busquedaEmpleado;

    public EmpleadoEstadisticas(IBusquedaEmpleado busquedaEmpleado)
    {
        _busquedaEmpleado = busquedaEmpleado;
    }

    public int ContarGerentesFeminino() =>
        _busquedaEmpleado.ObtenerEmpleadosPorGeneroYCargo(Genero.Femenino, Cargo.Gerente).Count();
}
```

Esto se ve mucho mejor ahora y está implementado por reglas `DIP`. Ahora, nuestra clase `EmpleadoEstadisticas` no depende de la clase de nivel inferior y la clase `EmpleadoGerente` también puede cambiar su comportamiento con respecto al almacenamiento de empleados.

Finalmente, podemos verificar el resultado modificando la clase `Program.cs`:

```csharp
class Program
{
    static void Main(string[] args)
    {
        EmpleadoGerente empleadoGerente = new();
        empleadoGerente.AgregarEmpleado(new Empleado { Nombre = "Fernando", Genero = Genero.Masculino, Cargo = Cargo.Administrador });
        empleadoGerente.AgregarEmpleado(new Empleado { Nombre = "Estefania", Genero = Genero.Femenino, Cargo = Cargo.Gerente });
        empleadoGerente.AgregarEmpleado(new Empleado { Nombre = "Sofia", Genero = Genero.Femenino, Cargo = Cargo.Gerente });
        empleadoGerente.AgregarEmpleado(new Empleado { Nombre = "Mario", Genero = Genero.Masculino, Cargo = Cargo.Gerente });

        var empleadoEstadisticas = new EmpleadoEstadisticas(empleadoGerente);
        var resultado = empleadoEstadisticas.ContarGerentesFeminino();
        Console.WriteLine($"El total de gerentes femeninos es: {resultado}");
    }
}
```

## Beneficios de implementar el principio de inversión de dependencia

- Reducir el número de dependencias entre módulos es una parte importante del proceso de creación de una aplicación. Esto es algo que conseguimos si implementamos `DIP` correctamente. Nuestras clases no están estrechamente vinculadas con los objetos de nivel inferior y podemos reutilizar fácilmente la lógica de los módulos de nivel superior.

- Entonces, la razón principal por la que `DIP` es tan importante es la modularidad y la reutilización de los módulos de aplicación.

- También es importante mencionar que cambiar módulos ya implementados es arriesgado. Al depender de la abstracción y no de una implementación concreta, podemos reducir ese riesgo al no tener que cambiar módulos de alto nivel en nuestro proyecto.

- Finalmente, `DIP` cuando se aplica correctamente nos brinda la flexibilidad y estabilidad a nivel de toda la arquitectura de nuestra aplicación. Nuestra aplicación podrá evolucionar de forma más segura y volverse estable y robusta.

---
[Regresar al menú principal](https://github.com/FernandoCalmet/dotnet-6-essencial)

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet