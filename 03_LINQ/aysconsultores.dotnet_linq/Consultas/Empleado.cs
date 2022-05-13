namespace aysconsultores.dotnet_linq.Consultas;

public enum Departamento
{
    RH = 201,
    Desarrollo = 520,
    Soporte = 402,
    Admin = 309
}
public class Empleado
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public Departamento Departamento { get; set; }
}