namespace aysconsultores.dotnet_solid._3_Sustitucion_Liskov.AplicandoPrincipio;

public abstract class Calculadora
{
    protected readonly int[] _numeros;
    public Calculadora(int[] numeros)
    {
        _numeros = numeros;
    }
    public abstract int Calcular();
}
