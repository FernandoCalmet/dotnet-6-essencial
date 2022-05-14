namespace aysconsultores.dotnet_solid._3_Sustitucion_Liskov.AplicandoPrincipio;

public class CalculadoraSumaNumerosPares : Calculadora
{
    public CalculadoraSumaNumerosPares(int[] numeros)
        : base(numeros)
    {
    }

    public override int Calcular() => _numeros.Where(n => n % 2 == 0).Sum();
}
