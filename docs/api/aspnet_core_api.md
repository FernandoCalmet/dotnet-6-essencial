[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# ASPNET CORE WEB API

## AddTransient Vs AddScoped Vs AddSingleton

### Introducción
 
Comprender el ciclo de vida de la inyección de dependencia (DI) es muy importante en las aplicaciones ASP.Net Core. Como sabemos, la inyección de dependencia (DI) es una técnica para lograr un acoplamiento flexible entre los objetos y sus colaboradores, o dependencias. La mayoría de las veces, las clases declararán sus dependencias a través de su constructor, lo que les permitirá seguir el Principio de Dependencias Explícitas. Este enfoque se conoce como "inyección de constructor".
 
Para implementar la inyección de dependencia, necesitamos configurar un contenedor DI con clases que participen en DI. DI Container tiene que decidir si devolver una nueva instancia del servicio o proporcionar una instancia existente. En la clase de inicio, realizamos esta actividad en el método ConfigureServices.
 
La vida útil del servicio depende de cuándo se crea una instancia de la dependencia y cuánto dura. Y de por vida depende de cómo hayamos registrado esos servicios.
 
Los tres métodos siguientes definen la vida útil de los servicios,

1. **AddTransient** : Los servicios transitorios de por vida se crean cada vez que se solicitan. Esta vida útil funciona mejor para servicios livianos y sin estado.

2. **AddScoped**: Scoped se crean una vez por solicitud.

3. **AddSingleton** : Singleton se crean la primera vez que se solicitan (o cuando se ejecuta ConfigureServices si especifica una instancia allí) y luego cada solicitud posterior utilizará la misma instancia.

Tipo de Servicio | En el alcance de una solicitud http dada | En el alcance de una solicitud http dada
--- | --- | ---
Transient | Nueva Instancia | Nueva Instancia
Scoped | Misma Instancia | Nueva Instancia
Singleton | Misma Instancia | Misma Instancia

- **Con un servicio transitorio (Transient)**, se proporciona una nueva instancia cada vez que se solicita una instancia, ya sea en el ámbito de la misma solicitud http o en diferentes solicitudes http.

- **Con un servicio de alcance (Scoped)**, obtenemos la misma instancia dentro del alcance de una solicitud http dada, pero una nueva instancia en diferentes solicitudes http.

- **Con el servicio Singleton (Singleton)**, solo hay una única instancia. Se crea una instancia, cuando se solicita el servicio por primera vez y esa instancia única será utilizada por todas las solicitudes http posteriores en toda la aplicación.

---
[Regresar al menú principal](https://github.com/FernandoCalmet/dotnet-6-essencial)

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet