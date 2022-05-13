namespace aysconsultores.dotnet_linq.Operadores;

public class Pago
{
    public string Descripcion { get; set; }
    public DateTime Fecha { get; set; }
    public float Monto { get; set; }
    public bool Procesado { get; set; }
    public int IdExternoEmpleado { get; set; }
}