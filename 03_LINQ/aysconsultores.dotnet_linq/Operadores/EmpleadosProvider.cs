namespace aysconsultores.dotnet_linq.Operadores;

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
                Departamento = Departamento.Desarrollo,
                Edad = 25,
                IdExterno = 5
            },
            new Empleado
            {
                Nombre = "Fiorela",
                Apellido = "Solano",
                Departamento = Departamento.Desarrollo,
                Edad = 40,
                IdExterno = 9,
                Pagos = new List<Pago>()
                {
                    new Pago
                    {
                        Descripcion = "Quincena #15: Noviembre",
                        Fecha = new DateTime(2022,11,01),
                        Monto = 12500.95f,
                        Procesado = true
                    },
                    new Pago
                    {
                        Descripcion = "Quincena #15: Diciembre",
                        Fecha = new DateTime(2022,12,01),
                        Monto = 12500.95f,
                        Procesado = true
                    }
                }
            },
            new Empleado
            {
                Nombre = "Jose",
                Apellido = "Perez",
                Departamento = Departamento.RH,
                Edad = 55,
                IdExterno = 12,
                Pagos = new List<Pago>()
                {
                    new Pago
                    {
                        Descripcion = "Quincena #1: Diciembre",
                        Fecha = new DateTime(2022,12,03),
                        Monto = 15000.95f,
                        Procesado = true
                    }
                }
            },
            new Empleado
            {
                Nombre = "Fransisco",
                Apellido = "Ramirez",
                Departamento = Departamento.Desarrollo,
                Edad = 19,
                IdExterno = 21
            },
            new Empleado
            {
                Nombre = "Juan",
                Apellido = "Lopez",
                Departamento = Departamento.Soporte,
                Edad = 55,
                IdExterno = 13,
                Pagos = new List<Pago>()
                {
                    new Pago
                    {
                        Descripcion = "Quincena #15: Noviembre",
                        Fecha = new DateTime(2022,11,01),
                        Monto = 12500.95f,
                        Procesado = true
                    },
                    new Pago
                    {
                        Descripcion = "Quincena #15: Diciembre",
                        Fecha = new DateTime(2022,12,01),
                        Monto = 12500.95f,
                        Procesado = true
                    }
                }
            },
            new Empleado
            {
                Nombre = "Josellin",
                Apellido = "Mendoza",
                Departamento = Departamento.Admin,
                Edad = 28,
                IdExterno = 25,
                Pagos = new List<Pago>()
                {
                    new Pago
                    {
                        Descripcion = "Quincena #1: Enero",
                        Fecha = new DateTime(2022,01,01),
                        Monto = 25000.95f,
                        Procesado = false
                    }
                }
            },
        };
    }

    public List<Empleado> ListarEmpleados()
    {
        return empleados;
    }
}