namespace aysconsultores.dotnet_linq.Consultas;

public class EmpleadosProvider
{
    private readonly List<Empleado> empleados;

    public EmpleadosProvider()
    {
        empleados = new()
        {
            new Empleado
            {
                Nombre = "Fernando",
                Apellido = "Calmet",
                Departamento = Departamento.Desarrollo
            },
            new Empleado
            {
                Nombre = "Fiorela",
                Apellido = "Solano",
                Departamento = Departamento.Desarrollo
            },
            new Empleado
            {
                Nombre = "Jose",
                Apellido = "Perez",
                Departamento = Departamento.RH
            },
            new Empleado
            {
                Nombre = "Fransisco",
                Apellido = "Ramirez",
                Departamento = Departamento.Desarrollo
            },
            new Empleado
            {
                Nombre = "Juan",
                Apellido = "Lopez",
                Departamento = Departamento.Soporte
            },
            new Empleado
            {
                Nombre = "Josellin",
                Apellido = "Mendoza",
                Departamento = Departamento.Admin
            },
        };
    }

    public List<Empleado> ListarEmpleados()
    {
        return empleados;
    }
}