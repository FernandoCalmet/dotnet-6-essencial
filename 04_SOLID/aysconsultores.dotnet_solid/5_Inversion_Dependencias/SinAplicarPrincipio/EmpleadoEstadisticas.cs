namespace aysconsultores.dotnet_solid._5_Inversion_Dependencias.SinAplicarPrincipio;

public class EmpleadoEstadisticas
{
    private readonly EmpleadoGerente _empleadoGerente;

    public EmpleadoEstadisticas(EmpleadoGerente empleadoGerente)
    {
        _empleadoGerente = empleadoGerente;
    }

    public int ContarGerentesFeminino() =>
        _empleadoGerente.Empleados.Count(emp => emp.Genero == Genero.Femenino && emp.Cargo == Cargo.Gerente);
}
