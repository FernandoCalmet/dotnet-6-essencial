namespace aysconsultores.dotnet_solid._2_Abierto_Cerrado.AplicandoPrincipio;

public class CalculadoraSalarioJunior : CalculadoraSalarioBase
{
    public CalculadoraSalarioJunior(InformeDesarrollador informeDesarrollador)
        : base(informeDesarrollador)
    {
    }

    public override double CalcularSalario()
    {
        return InformeDesarrollador.TarifaPorHora * InformeDesarrollador.HorasTrabajando;
    }
}
