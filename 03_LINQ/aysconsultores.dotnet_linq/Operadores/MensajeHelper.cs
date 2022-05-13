namespace aysconsultores.dotnet_linq.Operadores;

public static class MensajeHelper
{
    public static void ImprimeEmpleado(Empleado e)
    {
        string fila = string.Format("{0,-40} {1,-10} {2,-20} {3, -10} {4}",
            e.Id, e.Nombre, e.Apellido, e.Edad, e.Departamento);
        Console.WriteLine(fila);
    }

    public static void ImprimeEmpleados(IEnumerable<Empleado> lista, string titulo = "/** --- **")
    {
        Console.WriteLine(titulo);
        var encabezado = string.Format("{0,-40} {1,-10} {2,-20} {3, -10} {4}",
            "ID", "Nombre", "Apellido", "Edad", "Departamento");
        Console.WriteLine(encabezado);
        foreach (var e in lista) ImprimeEmpleado(e);
    }
}