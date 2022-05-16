using aysconsultores.dotnet_pdd_aggregates.ModelosAgregados.MascotaAgregado;

List<Mascota> mascotas = new();

#region Crear Mascotas
var mascota1Nombre = MascotaNombre.Crear("Michifu");
var mascota1Nacimiento = MascotaNacimiento.Crear(new DateOnly(2019, 5, 3));
var mascota1 = new Mascota(mascota1Nombre, mascota1Nacimiento);
mascotas.Add(mascota1);

var mascota2Nombre = MascotaNombre.Crear("Chini");
var mascota2Nacimiento = MascotaNacimiento.Crear(new DateOnly(2020, 12, 2));
var mascota2 = new Mascota(mascota2Nombre, mascota2Nacimiento);
mascotas.Add(mascota2);

var mascota3Nombre = MascotaNombre.Crear("Firulais");
var mascota3Nacimiento = MascotaNacimiento.Crear(new DateOnly(2021, 7, 1));
var mascota3 = new Mascota(mascota3Nombre, mascota3Nacimiento);
mascotas.Add(mascota3);
#endregion

#region Mostrar todas las mascotas
foreach (var mascota in mascotas)
{
    Console.WriteLine($"Nombre: {mascota.Nombre.Valor}, Nacimiento: {mascota.Nacimiento.Valor}");
}
#endregion