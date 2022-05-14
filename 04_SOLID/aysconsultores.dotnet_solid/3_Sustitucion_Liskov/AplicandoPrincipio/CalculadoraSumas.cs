namespace aysconsultores.dotnet_solid._3_Sustitucion_Liskov.AplicandoPrincipio;

public class CalculadoraSumas : Calculadora
{
    public CalculadoraSumas(int[] numeros)
        : base(numeros)
    {
    }

    public override int Calcular() => _numeros.Sum();
}
