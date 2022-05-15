namespace aysconsultores.dotnet_solid._5_Inversion_Dependencias.AplicandoPrincipio;

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
