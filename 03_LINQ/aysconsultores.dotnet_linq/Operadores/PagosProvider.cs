namespace aysconsultores.dotnet_linq.Operadores;

public class PagosProvider
{
    private readonly List<Pago> pagos;

    public PagosProvider()
    {
        pagos = new()
        {
            new Pago
            {
                Descripcion = "Quincena #1: Enero",
                Fecha = new DateTime(2022, 01, 01),
                Monto = 25000.95f,
                Procesado = false,
                IdExternoEmpleado = 9
            },
            new Pago
            {
                Descripcion = "Quincena #10: Noviembre",
                Fecha = new DateTime(2022, 11, 01),
                Monto = 12500.95f,
                Procesado = true,
                IdExternoEmpleado = 25
            },
            new Pago
            {
                Descripcion = "Quincena #15: Diciembre",
                Fecha = new DateTime(2022, 12, 01),
                Monto = 12500.95f,
                Procesado = true,
                IdExternoEmpleado = 13
            },
            new Pago
            {
                Descripcion = "Quincena #3: Enero",
                Fecha = new DateTime(2022, 01, 01),
                Monto = 25000.95f,
                Procesado = false,
                IdExternoEmpleado = 21
            },
            new Pago
            {
                Descripcion = "Quincena #2: Diciembre",
                Fecha = new DateTime(2022, 12, 01),
                Monto = 12500.95f,
                Procesado = true,
                IdExternoEmpleado = 12
            },
            new Pago
            {
                Descripcion = "Quincena #13: Enero",
                Fecha = new DateTime(2022, 01, 01),
                Monto = 25000.95f,
                Procesado = false,
                IdExternoEmpleado = 5
            }
        };
    }

    public List<Pago> ListarPagos()
    {
        return pagos;
    }
}