namespace aysconsultores.dotnet_pdd_aggregates.ModelosAgregados.MascotaAgregado;

public class MascotaNacimiento
{
    public DateOnly Valor { get; init; }
    internal MascotaNacimiento(DateOnly valor)
    {
        Validar(valor);
        Valor = valor;
    }
    public static MascotaNacimiento Crear(DateOnly valor) => new MascotaNacimiento(valor);
    private static void Validar(DateOnly valor)
    {
        if (valor > DateOnly.FromDateTime(DateTime.Now))
            throw new ArgumentOutOfRangeException(nameof(valor), "La fecha de nacimiento no es valida.");
    }
}
