namespace aysconsultores.dotnet_solid._2_Abierto_Cerrado.SinAplicarPrincipio;

public class CalculadoraSalario
{
    private readonly IEnumerable<InformeDesarrollador> _informesDesarrolladores;
    public CalculadoraSalario(List<InformeDesarrollador> informesDesarrolladores)
    {
        _informesDesarrolladores = informesDesarrolladores;
    }
    public double CalcularSalarioTotal()
    {
        #region Requerimiento #1
        double salariosTotal = 0D;
        foreach (var informeDesarrollador in _informesDesarrolladores)
        {
            salariosTotal += informeDesarrollador.TarifaPorHora * informeDesarrollador.HorasTrabajando;
        }
        return salariosTotal;
        #endregion

        #region Requerimiento #2 (Bnoificación de 20% salario para desarrolladores senior)
        //foreach (var informeDesarrollador in _informesDesarrolladores)
        //{
        //    if(informeDesarrollador.Nivel == "Senior developer")
        //    {
        //        salariosTotal += informeDesarrollador.TarifaPorHora * informeDesarrollador.HorasTrabajando * 1.2;
        //    }
        //    else
        //    {
        //        salariosTotal += informeDesarrollador.TarifaPorHora * informeDesarrollador.HorasTrabajando;
        //    }
        //}
        //return salariosTotal;
        #endregion
    }
}
