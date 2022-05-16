namespace aysconsultores.dotnet_pdd_aggregates.ModelosAgregados.MascotaAgregado;

public record MascotaNombre
{
    public string Valor { get; init; }
    internal MascotaNombre(string valor)
    {
        Validar(valor);
        Valor = valor;
    }
    public static MascotaNombre Crear(string valor) => new MascotaNombre(valor);
    private static void Validar(string valor)
    {
        if (string.IsNullOrEmpty(valor))
            throw new ArgumentException("El nombre de la mascota no puede estar vacío");
        if (valor.Length > 50)
            throw new ArgumentException("El nombre de la mascota no puede tener más de 50 caracteres");
    }
}
