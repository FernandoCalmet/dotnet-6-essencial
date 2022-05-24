[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# PRINCIPIO DE SEGREGRACIÓN DE INTERFACES

El principio de segregación de la interfaz establece que ningún cliente debe verse obligado a depender de métodos que no utiliza. 

Imaginemos que estamos comenzando una nueva función en nuestro proyecto. Comenzamos con algo de código y de ese código emerge una interfaz con las declaraciones requeridas. Poco después, el cliente decide que quiere otra característica similar a la anterior y decidimos implementar la misma interfaz en otra clase. Pero ahora, como consecuencia, no necesitamos todos los métodos de esa interfaz, solo algunos de ellos. Por supuesto, tenemos que implementar todos los métodos, que no deberíamos tener que hacerlo, y ese es el problema y donde el ISP nos ayuda mucho.

Básicamente, el `ISP` establece que debemos reducir los objetos de código a la implementación requerida más pequeña, creando así interfaces con solo las declaraciones requeridas. Como resultado, una interfaz que tiene muchas declaraciones diferentes debe dividirse en interfaces más pequeñas.

## Ejemplo inicial

Hay vehículos que podemos conducir y hay otros con los que podemos volar. Pero hay autos que podemos conducir y volar (sí, esos están en oferta). Entonces, queremos crear una estructura de código que admita todas las acciones para un solo vehículo, y vamos a comenzar con una interfaz:

```csharp
public interface IVehiculo
{
    void Conducir();
    void Volar();
}
```

Ahora bien, si queremos desarrollar un comportamiento para un automóvil multifuncional, esta interfaz nos va a ser perfecta:

```csharp
public class AutomovilMultiFuncional : IVehiculo
{
    public void Conducir()
    {
        Console.WriteLine("Conducir un automovil multifuncional.");
    }

    public void Volar()
    {
        Console.WriteLine("Volar un automovil multifuncional.");
    }
}
```

Esto está funcionando muy bien. Nuestra interfaz cubre todas las acciones requeridas.

Pero ahora, queremos implementar la clase `automovil` y la clase `aeroplano` también:

```csharp
public class Automovil : IVehiculo
{
    public void Conducir()
    {
        Console.WriteLine("Conducir un automovil.");
    }

    public void Volar()
    {
        throw new NotImplementedException();
    }
}
```

```csharp
public class Aeroplano : IVehiculo
{
    public void Conducir()
    {
        throw new NotImplementedException();
    }

    public void Volar()
    {
        Console.WriteLine("Volar un aeroplano.");
    }
}
```

Ahora podemos ver cuál `IVehiculo` es el problema con la interfaz. Contiene solo una declaración requerida por cada clase. El otro método, que no es obligatorio, se implementa para generar una excepción. Esa es una mala idea porque deberíamos estar escribiendo nuestro código para hacer algo y no solo para lanzar excepciones. Además, tendríamos que hacer un esfuerzo adicional para documentar nuestra clase para que los usuarios sepan por qué no deberían usar el método no implementado. Una muy mala idea.

Entonces, para solucionar este problema, vamos a refactorizar nuestro código y escribirlo de acuerdo con el `ISP`.

## Implementando el ISP en la solución actual

Lo primero que vamos a hacer es dividir nuestra interfaz `IVehiculo`:

```csharp
public interface IAutomovil
{
    void Conducir();
}
```

```csharp
public interface IAeroplano
{
    void Volar();
}
```

Como resultado, nuestras clases pueden implementar solo los métodos que necesitan:

```csharp
public class Automovil : IAutomovil
{
    public void Conducir()
    {
        Console.WriteLine("Conducir automovil");
    }
}
```

```csharp
public class Aeroplano : IAeroplano
{
    public void Volar()
    {
        Console.WriteLine("Volar aeroplano");
    }

```

```csharp
public class AutomovilMultiFuncional : IAutomovil, IAeroplano
{
    public void Conducir()
    {
        Console.WriteLine("Conducir automovil multifuncional");
    }

    public void Volar()
    {
        Console.WriteLine("Volar automovil multifuncional");
    }
}
```

Incluso podemos usar una interfaz de nivel superior si queremos en una situación en la que una sola clase implementa más de una interfaz:

```csharp
public interface IAutomovilMultiFuncional : IAutomovil, IAeroplano
{
}
```

Una vez que tengamos nuestra interfaz de nivel superior, podemos implementarla de diferentes maneras. El primero es implementar los métodos requeridos:

```csharp
public class AutomovilMultiFuncional : IAutomovilMultiFuncional
{
    public void Conducir()
    {
        Console.WriteLine("Conducir automovil multifuncional");
    }

    public void Volar()
    {
        Console.WriteLine("Volar automovil multifuncional");
    }
}
```

O si ya hemos implementado la clase Coche y la clase Avión, podemos usarlas dentro de nuestra clase usando el patrón decorador:

```csharp
public class AutomovilMultiFuncional : IAutomovilMultiFuncional
{
    private readonly IAutomovil _automovil;
    private readonly IAeroplano _aeroplano;
    public AutomovilMultiFuncional(IAutomovil automovil, IAeroplano aeroplano)
    {
        _automovil = automovil;
        _aeroplano = aeroplano;
    }
    public void Conducir()
    {
        _automovil.Conducir();
    }
    public void Volar()
    {
        _aeroplano.Volar();
    }
}
```

## ¿Cuáles son los beneficios del principio de segregación de interfaz?

- Podemos ver en el ejemplo anterior que la interfaz más pequeña es mucho más fácil de implementar debido a que no es necesario implementar métodos que nuestra clase no necesita.

- Por supuesto, debido a la simplicidad de nuestro ejemplo, podemos crear una sola interfaz con un solo método dentro. Pero en los proyectos del mundo real, a menudo creamos una interfaz con múltiples métodos, lo cual es perfectamente normal siempre que esos métodos estén muy relacionados entre sí. Por lo tanto, nos aseguramos de que nuestra clase necesite todas estas acciones para completar su tarea.

- Otro beneficio es que el Principio de segregación de la interfaz aumenta la legibilidad y el mantenimiento de nuestro código. Estamos reduciendo la implementación de nuestra clase solo a las acciones requeridas sin ningún código adicional o innecesario.

---
[Regresar al menú principal](https://github.com/FernandoCalmet/dotnet-6-essencial)

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet