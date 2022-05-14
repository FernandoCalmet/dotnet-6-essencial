namespace aysconsultores.dotnet_solid._2_Abierto_Cerrado.AplicandoPrincipio;

public class CalculadoraSalario
{
    private readonly IEnumerable<CalculadoraSalarioBase> _calculoDesarrollador;
    public CalculadoraSalario(IEnumerable<CalculadoraSalarioBase> calculoDesarrollador)
    {
        _calculoDesarrollador = calculoDesarrollador;
    }
    public double CalcularSalarioTotal()
    {
        double salariosTotales = 0D;
        foreach (var calculo in _calculoDesarrollador)
        {
            salariosTotales += calculo.CalcularSalario();
        }
        return salariosTotales;
    }
}
