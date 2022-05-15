namespace aysconsultores.dotnet_solid._5_Inversion_Dependencias.AplicandoPrincipio;

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
