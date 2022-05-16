namespace aysconsultores.dotnet_pdd_aggregates.ModelosAgregados.MascotaAgregado;

public class Mascota
{
    public Guid Id { get; init; }
    public MascotaNombre Nombre { get; private set; }
    public MascotaNacimiento Nacimiento { get; private set; }

    private Mascota() { }

    public Mascota(MascotaNombre nombre, MascotaNacimiento nacimiento)
    {
        Id = Guid.NewGuid();
        Nombre = nombre;
        Nacimiento = nacimiento;
    }

    public void CambiarNombre(MascotaNombre nombre)
    {
        Nombre = nombre;
    }

    public void CambiarNacimiento(MascotaNacimiento nacimiento)
    {
        Nacimiento = nacimiento;
    }
}
