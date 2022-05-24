[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# PRINCIPIO DE SUSTITUCIÓN DE LISKOV

El principio de sustitución de Liskov (LSP) establece que los objetos de la clase secundaria deberían poder reemplazar los objetos de la clase principal sin comprometer la integridad de la aplicación. Lo que esto significa esencialmente es que debemos esforzarnos por crear tales objetos de clase derivados que puedan reemplazar objetos de la clase base sin modificar su comportamiento. Si no lo hacemos, nuestra aplicación podría terminar estropeándose.

**¿Tiene sentido esto para ti?**

## Proyecto Inicial

En este ejemplo, vamos a tener una matriz de números y una funcionalidad base para sumar todos los números de esa matriz. Pero digamos que necesitamos sumar solo números pares o impares.

¿Cómo implementaríamos eso? Veamos una forma de hacerlo:

```csharp
public class CalculadoraSumas
{
    protected readonly int[] _numeros;
    public CalculadoraSumas(int[] numeros)
    {
        _numeros = numeros;
    }
    public int Calcular() => _numeros.Sum();
}
```

```csharp
public class CalculadoraSumaNumerosPares : CalculadoraSumas
{
    public CalculadoraSumaNumerosPares(int[] numeros)
        : base(numeros)
    {
    }

    public new int Calcular() => _numeros.Where(n => n % 2 == 0).Sum();
}
```

Ahora, si probamos esta solución, ya sea que calculemos la suma de todos los números o la suma de solo los números pares, seguramente obtendremos el resultado correcto:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var numeros = new int[] { 5, 7, 9, 8, 1, 6, 4 };
        CalculadoraSumas suma = new CalculadoraSumas(numeros);
        Console.WriteLine($"La suma de todos los números: {suma.Calcular()}");
        CalculadoraSumas sumaPares = new CalculadoraSumaNumerosPares(numeros);
        Console.WriteLine($"La suma de todos los números pares: {sumaPares.Calcular()}");
    }
}
```

## Crear una mejor solución

Como podemos ver, esto está funcionando bien. Pero, ¿qué tiene de malo esta solución entonces?

### ¿Por qué estamos tratando de arreglarlo?

Bueno, como todos sabemos, si una clase secundaria hereda de una clase principal, entonces la clase secundaria es una clase principal. Teniendo eso en cuenta, deberíamos poder almacenar una referencia a `CalculadoraSumaNumerosPares` como una variable `CalculadoraSumas` y nada debería cambiar. Entonces, echemos un vistazo a eso:

```csharp
Calculadora sumaPares = new CalculadoraSumaNumerosPares(numeros);
Console.WriteLine($"La suma de todos los números pares: {sumaPares.Calcular()}");
```

Como podemos ver, no estamos obteniendo el resultado esperado porque nuestra variable `sumaPares` es de un tipo `CalculadoraSumas` que es una clase de orden superior (una clase base). Esto significa que se ejecutará el método `Count` de la clase `CalculadoraSumas`. Entonces, esto no es correcto, obviamente, porque nuestra clase secundaria no se comporta como un sustituto de la clase principal.

Por suerte, la solución es bastante sencilla. Todo lo que tenemos que hacer es implementar pequeñas modificaciones a nuestras dos clases:

```csharp
public class CalculadoraSumas
{
    protected readonly int[] _numeros;
    public CalculadoraSumas(int[] numeros)
    {
        _numeros = numeros;
    }
    public virtual int Calcular() => _numeros.Sum();
}
```

```csharp
public class CalculadoraSumaNumerosPares : CalculadoraSumas
{
    public CalculadoraSumaNumerosPares(int[] numeros)
        : base(numeros)
    {
    }

    public override int Calcular() => _numeros.Where(n => n % 2 == 0).Sum();
}
```

Como resultado, cuando comenzamos nuestra solución, todo funciona como se esperaba y la suma de los números pares vuelve a ser 18.

Entonces, expliquemos este comportamiento. Si tenemos una referencia de objeto secundario almacenada en una variable de objeto principal y llamamos al método `Calcular`, el compilador utilizará el método `Calcular` de la clase principal. Pero en este momento, debido a que el método `Calcular` se define como "virtual" y se anula en la clase secundaria, se usará ese método en la clase secundaria en su lugar.

## Implementando el principio de sustitución de Liskov

Aún así, el comportamiento de nuestra clase derivada ha cambiado y no puede reemplazar a la clase base. Entonces necesitamos actualizar esta solución introduciendo la clase abstracta `Calculadora`:

```csharp
public abstract class Calculadora
{
    protected readonly int[] _numeros;
    public Calculadora(int[] numeros)
    {
        _numeros = numeros;
    }
    public abstract int Calcular();
}
```

Entonces tenemos que cambiar nuestras otras clases:

```csharp
public class CalculadoraSumas : Calculadora
{
    public CalculadoraSumas(int[] numeros)
        : base(numeros)
    {
    }

    public override int Calcular() => _numeros.Sum();
}
```

```csharp
public class CalculadoraSumaNumerosPares : Calculadora
{
    public CalculadoraSumaNumerosPares(int[] numeros)
        : base(numeros)
    {
    }

    public override int Calcular() => _numeros.Where(n => n % 2 == 0).Sum();
}
```

Excelente. Ahora podemos empezar a hacer llamadas hacia estas clases:

```csharp
 class Program
{
    static void Main(string[] args)
    {
        var numeros = new int[] { 5, 7, 9, 8, 1, 6, 4 };
        Calculadora suma = new CalculadoraSumas(numeros);
        Console.WriteLine($"La suma de todos los números: {suma.Calcular()}");
        Console.WriteLine();
        Calculadora sumaPares = new CalculadoraSumaNumerosPares(numeros);
        Console.WriteLine($"La suma de todos los números pares: {sumaPares.Calcular()}");
    }
}
```

Volveremos a tener el mismo resultado, 40 para todos los números y 18 para los números pares. Pero ahora, podemos ver que podemos almacenar cualquier referencia de subclase en una variable de clase base y el comportamiento no cambiará, que es el objetivo de `LSP`.

## Lo que ganamos al implementar el LSP

- Al implementar el LSP, mantenemos nuestra funcionalidad intacta y nuestras subclases siguen actuando como un sustituto de una clase base.

- Además, alentamos la reutilización del código mediante la implementación del LSP y un mejor mantenimiento del proyecto.

---
[Regresar al menú principal](https://github.com/FernandoCalmet/dotnet-6-essencial)

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet