namespace aysconsultores.dotnet_solid._2_Abierto_Cerrado.AplicandoPrincipio;

public class CalculadoraSalarioSenior : CalculadoraSalarioBase
{
    public CalculadoraSalarioSenior(InformeDesarrollador informeDesarrollador)
        : base(informeDesarrollador)
    {
    }

    public override double CalcularSalario()
    {
        return InformeDesarrollador.TarifaPorHora * InformeDesarrollador.HorasTrabajando * 1.2;
    }
}
