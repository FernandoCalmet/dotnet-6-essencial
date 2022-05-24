[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# PRINCIPIOS DE DISESÑO ORIENTADO A OBJETOS

## Características de un Buen Diseño

- **Reusabilidad de código**
    - Mediante frameworks.
    - Mediante patrones de diseño.
    - Diversas tecnologías en programación orientada a objetos.
    - Reducir costos de desarrollo de software.
- **Extensibilidad**
    - Adaptación al cambio constante en el desarrollo de software.
    - Capacidad de intercambio de componentes.
    - Capacidad de adaptarse a otros sistemas operativos.
    - Código extensible y escalable.

## Principios de Diseño

- **Favorece la composición sobre la herencia.**
    - La herencia puede conllevar a una gran cantidad de subclases, sin embargo con la composición nos brinda diferentes "dimensiones" de funcionalidad extraídas a sus propia jerarquía de clases.
- **Programa Interface no Implementación.**
    - Desacoplar las clases concretas para usar el polimorfismo y que nos permita trabajar con una clase concreta independiente a las demás.
- **Encapsula lo que varia.**
    - Identificar aspectos de la aplicación que varían y separarla del código que permanece invariable.
    - Minimizar el efecto causado por los cambios.

## Principios SOLID

Presentados por *Robert C. Martin* en su libro *Agile Software Development Principles Patterns and Practices*.

SOLID es un nemónico de cinco principios de diseño que pretenden hacer el diseño de software mas comprensible, flexible y extensible.

1. **S**: Single Responsabilidad Principle
2. **O**: Open/Close Principle
3. **L**: Liskov Separation Principle
4. **I**: Interface Segregation Principle
5. **D**: Dependency Inverse Principle

### Principio de Responsabilidad Única (S)

Solo debe haber una razón por la cual deba cambiarse una clase. Es decir que una clase debe tener una tarea que hacer. Este principio a menudo se denomina subjetivo.

### Principio de Abierto y Cerrado (O)

Los componentes de software deben estar abiertos para su extensión, pero cerrados para modificaciones. Es decir una clase debe escribirse de tal manera que realice su trabajo, y si en caso a futuro una persona pueda realizar cambios sin problemas, teniendo la opción de ampliarse.

### Principio de Sustitución de Liskov (L)

Establece que el diseño debe proporcionar la habilidad de reemplazar cualquier instancia de la clase padre con una instancia de una de sus clases hijas. Si la clase padre hace algo la clase hija también debe poder hacerlo.

### Principio de Segregación de Interfaces (I)

Un cliente, no importa cual, nunca debe estar obligado a implementar una interfaz que no usa o el cliente nunca debe estar obligado a depender de ningún método que no sea utilizado por ellos. 

### Principio de Inversión de Dependencia (D)

Las clases de alto nivel no deben depender de las clases de bajo nivel. Ambas deben depender de abstracciones.

---
[Regresar al menú principal](https://github.com/FernandoCalmet/dotnet-6-essencial)

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet