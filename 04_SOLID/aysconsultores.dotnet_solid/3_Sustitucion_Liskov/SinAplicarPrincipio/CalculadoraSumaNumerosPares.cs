namespace aysconsultores.dotnet_solid._3_Sustitucion_Liskov.SinAplicarPrincipio;

public class CalculadoraSumaNumerosPares : CalculadoraSumas
{
    public CalculadoraSumaNumerosPares(int[] numeros)
        : base(numeros)
    {
    }

    public override int Calcular() => _numeros.Where(n => n % 2 == 0).Sum();
}
