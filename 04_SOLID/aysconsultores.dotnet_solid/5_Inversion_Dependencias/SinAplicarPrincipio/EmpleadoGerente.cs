namespace aysconsultores.dotnet_solid._5_Inversion_Dependencias.SinAplicarPrincipio;

public class EmpleadoGerente
{
    private readonly List<Empleado> _empleados;

    public EmpleadoGerente()
    {
        _empleados = new();
    }

    public void AgregarEmpleado(Empleado empleado)
    {
        _empleados.Add(empleado);
    }

    #region Metodo adicional para exponer la lista de empleados
    public List<Empleado> Empleados => _empleados;
    #endregion
}
