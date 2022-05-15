namespace aysconsultores.dotnet_solid._5_Inversion_Dependencias.AplicandoPrincipio;

public interface IBusquedaEmpleado
{
    IEnumerable<Empleado> ObtenerEmpleadosPorGeneroYCargo(Genero genero, Cargo cargo);
}
