namespace aysconsultores.dotnet_solid._2_Abierto_Cerrado.AplicandoPrincipio;

public abstract class CalculadoraSalarioBase
{
    protected InformeDesarrollador InformeDesarrollador { get; private set; }
    public CalculadoraSalarioBase(InformeDesarrollador informeDesarrollador)
    {
        InformeDesarrollador = informeDesarrollador;
    }
    public abstract double CalcularSalario();
}
