namespace aysconsultores.dotnet_solid._3_Sustitucion_Liskov.SinAplicarPrincipio;

public class CalculadoraSumas
{
    protected readonly int[] _numeros;
    public CalculadoraSumas(int[] numeros)
    {
        _numeros = numeros;
    }
    public virtual int Calcular() => _numeros.Sum();
}
