[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# COMANDOS BÁSICOS DE ENTITYFRAMEWORK CORE

📌Instalar EF Core global tool.

```bash
dotnet tool install --global dotnet-ef
```

📌Actualizar la versión del efcore

```bash
dotnet tool update --global dotnet-ef
```

📌Mostrar la informacion del contexto de la base de datos.

```bash
dotnet-ef dbcontext info
```

📌Realizar una migración

```bash
dotnet-ef migrations '<NAME>'
```

📌Listar todas las migraciones del proyecto.

```bash
dotnet-ef migrations list
```

📌Actualizar migración en base de datos

```bash
dotnet-ef database update
```

📌Borrar una base de datos.

```bash
dotnet-ef database drop
```

📌Crear un script transact-sql a partir de una migracion.

```bash
dotnet-ef migrations script
```

---
[Regresar al menú principal](https://github.com/FernandoCalmet/dotnet-6-essencial)

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet