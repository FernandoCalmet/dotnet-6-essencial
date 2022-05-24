[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# PRINCIPIO DE ABIERTO Y CERRADO

El Principio Abierto Cerrado (OCP) es el principio SOLID que establece que las entidades de software (clases o métodos) deben estar abiertas para la extensión pero cerradas para la modificación.

Pero, ¿qué significa esto realmente?

Básicamente, debemos esforzarnos por escribir un código que no requiera modificaciones cada vez que un cliente cambia su solicitud. Proporcionar una solución en la que podamos ampliar el comportamiento de una clase (con la solicitud de ese cliente adicional) y no modificar esa clase, debería ser nuestro objetivo la mayor parte del tiempo.

## Ejemplo de calculadora de salario

Imaginemos que tenemos una tarea en la que necesitamos calcular el costo total de todos los salarios de los desarrolladores en una sola empresa. Por supuesto, vamos a simplificar este ejemplo y centrarnos en el tema requerido.

Para comenzar, primero vamos a crear la clase modelo:

```csharp
public class InformeDesarrollador
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Nivel { get; set; }
    public int HorasTrabajando { get; set; }
    public double TarifaPorHora { get; set; }
}
```

Una vez que hayamos creado nuestro modelo, podemos pasar a la función de cálculo de salarios:

```csharp
public class CalculadoraSalario
{
    private readonly IEnumerable<InformeDesarrollador> _informesDesarrolladores;
    public CalculadoraSalario(List<InformeDesarrollador> informesDesarrolladores)
    {
        _informesDesarrolladores = informesDesarrolladores;
    }
    public double CalcularSalarioTotal()
    {
        double salariosTotal = 0D;
        foreach (var informeDesarrollador in _informesDesarrolladores)
        {
            salariosTotal += informeDesarrollador.TarifaPorHora * informeDesarrollador.HorasTrabajando;
        }
        return salariosTotal;
    }
}
```

Ahora, todo lo que tenemos que hacer es proporcionar algunos datos para esta clase y vamos a calcular nuestros costos totales:

```csharp
static void Main(string[] args)
{
    var informesDesarrolladores = new List<InformeDesarrollador>
    {
        new InformeDesarrollador {Id = 1, Nombre = "Dev1", Nivel = "Senior developer", TarifaPorHora  = 30.5, HorasTrabajando = 160 },
        new InformeDesarrollador {Id = 2, Nombre = "Dev2", Nivel = "Junior developer", TarifaPorHora  = 20, HorasTrabajando = 150 },
        new InformeDesarrollador {Id = 3, Nombre = "Dev3", Nivel = "Senior developer", TarifaPorHora  = 30.5, HorasTrabajando = 180 }
    };
    var calculadora = new CalculadoraSalario(informesDesarrolladores);
    Console.WriteLine($"La suma de todos los salarios de los desarrolladores es {calculadora.CalcularSalarioTotal()} dolares");
}
```

## Primer ejemplo de Principio Abierto Cerrado

Entonces, todo esto funciona muy bien, pero ahora nuestro jefe viene a nuestra oficina y dice que necesitamos un cálculo diferente para los desarrolladores senior y junior. Los desarrolladores senior deberían tener una bonificación del 20% sobre un salario.

Por supuesto, para satisfacer este requisito, vamos a modificar nuestro método `CalculadoraSalario` de esta manera:

```csharp
public class CalculadoraSalario
{
    private readonly IEnumerable<InformeDesarrollador> _informesDesarrolladores;
    public CalculadoraSalario(List<InformeDesarrollador> informesDesarrolladores)
    {
        _informesDesarrolladores = informesDesarrolladores;
    }
    public double CalcularSalarioTotal()
    {
        foreach (var informeDesarrollador in _informesDesarrolladores)
        {
           if(informeDesarrollador.Nivel == "Senior developer")
           {
               salariosTotal += informeDesarrollador.TarifaPorHora * informeDesarrollador.HorasTrabajando * 1.2;
           }
           else
           {
               salariosTotal += informeDesarrollador.TarifaPorHora * informeDesarrollador.HorasTrabajando;
           }
        }
        return salariosTotal;
    }
}
```

Aunque esta solución nos va a dar el resultado correcto, no es una solución óptima.

### ¿Porqué es eso?

Principalmente, porque tuvimos que modificar nuestro comportamiento de clase existente que funcionó perfectamente. Otra cosa es que si nuestro jefe vuelve y nos pide que modifiquemos el cálculo para los desarrolladores junior también, tendríamos que cambiar nuestra clase nuevamente. Esto está totalmente en contra de lo que significa `OCP`.

Es obvio que necesitamos cambiar algo en nuestra solución, así que hagámoslo.

## Ejemplo de Calculadora de Mejor Salario - OCP implementado

Para crear un código que cumpla con el Principio Abierto Cerrado, primero vamos a crear una clase abstracta:

```csharp
public abstract class CalculadoraSalarioBase
{
    protected InformeDesarrollador InformeDesarrollador { get; private set; }
    public CalculadoraSalarioBase(InformeDesarrollador informeDesarrollador)
    {
        InformeDesarrollador = informeDesarrollador;
    }
    public abstract double CalcularSalario();
}
```

A continuación, vamos a crear dos clases que heredarán de la clase `CalculadoraSalarioBase`. Como es obvio que nuestro cálculo depende del nivel del desarrollador, vamos a crear nuestras nuevas clases de esa manera:

```csharp
public class CalculadoraSalarioSenior : CalculadoraSalarioBase
{
    public CalculadoraSalarioSenior(InformeDesarrollador informeDesarrollador)
        : base(informeDesarrollador)
    {
    }

    public override double CalcularSalario()
    {
        return InformeDesarrollador.TarifaPorHora * InformeDesarrollador.HorasTrabajando * 1.2;
    }
}
```

```csharp
public class CalculadoraSalarioJunior : CalculadoraSalarioBase
{
    public CalculadoraSalarioJunior(InformeDesarrollador informeDesarrollador)
        : base(informeDesarrollador)
    {
    }

    public override double CalcularSalario()
    {
        return InformeDesarrollador.TarifaPorHora * InformeDesarrollador.HorasTrabajando;
    }
}
```

Excelente. Ahora podemos modificar la clase `CalculadoraSalario`:

```csharp
public class CalculadoraSalario
{
    private readonly IEnumerable<CalculadoraSalarioBase> _calculoDesarrollador;
    public CalculadoraSalario(IEnumerable<CalculadoraSalarioBase> calculoDesarrollador)
    {
        _calculoDesarrollador = calculoDesarrollador;
    }
    public double CalcularSalarioTotal()
    {
        double salariosTotales = 0D;
        foreach (var calculo in _calculoDesarrollador)
        {
            salariosTotales += calculo.CalcularSalario();
        }
        return salariosTotales;
    }
}
```

Esto se ve mucho mejor porque no tendremos que cambiar ninguna de nuestras clases actuales si nuestro jefe viene con otra solicitud sobre el cálculo del pago interno o cualquier otra también.

Todo lo que tenemos que hacer ahora es agregar otra clase con su propia lógica de cálculo. Básicamente, nuestra clase `CalculadoraSalario` ahora está cerrada para modificaciones y abierta para una extensión, que es exactamente lo que establece `OCP`.

Para terminar este ejemplo, modifiquemos la clase `Program.cs`:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var informesDesarrolladores = new List<CalculadoraSalarioBase>
        {
            new CalculadoraSalarioSenior(new InformeDesarrollador {Id = 1, Nombre = "Dev1", Nivel = "Senior developer", TarifaPorHora  = 30.5, HorasTrabajando = 160 }),
            new CalculadoraSalarioJunior(new InformeDesarrollador {Id = 2, Nombre = "Dev2", Nivel = "Junior developer", TarifaPorHora  = 20, HorasTrabajando = 150 }),
            new CalculadoraSalarioSenior(new InformeDesarrollador {Id = 3, Nombre = "Dev3", Nivel = "Senior developer", TarifaPorHora  = 30.5, HorasTrabajando = 180 })
        };
        var calculadora = new CalculadoraSalario(informesDesarrolladores);
        Console.WriteLine($"La suma de todos los salarios de los desarrolladores es {calculadora.CalcularSalarioTotal()} dolares");
    }
} 
```

## ¿Por qué deberíamos implementar el principio abierto cerrado?

- Al implementar OCP, estamos reduciendo la posibilidad de producir errores en nuestro proyecto.

- Por ejemplo, si tenemos una clase completamente funcional y ya probada en producción, al extenderla en lugar de cambiarla, definitivamente tendríamos un impacto menor en el resto del sistema.

- Por lo tanto, introducimos otra clase para ampliar el comportamiento de la clase principal y así evitar la modificación de la funcionalidad existente en la que pueden confiar otras clases.

- Otro beneficio es que solo tenemos que probar e implementar las nuevas funciones, lo que no sería el caso si tuviéramos que cambiar la funcionalidad existente. Además, si decidimos que ya no necesitamos esta característica (en algún momento en el futuro), todo lo que tenemos que hacer es revertir solo el cambio recién implementado y eso es todo.

---
[Regresar al menú principal](https://github.com/FernandoCalmet/dotnet-6-essencial)

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet