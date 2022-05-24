namespace aysconsultores.dotnet_solid._1_Responsabilidad_Unica.SolucionMejorada;

public class InformeTrabajo : IGestorEntrada<EntradaInformeTrabajo>
{
    private readonly List<EntradaInformeTrabajo> _entradas;
    public InformeTrabajo()
    {
        _entradas = new List<EntradaInformeTrabajo>();
    }
    public void AgregarEntrada(EntradaInformeTrabajo entrada) => _entradas.Add(entrada);
    public void RemoverEntradaPorIndice(int indice) => _entradas.RemoveAt(indice);
    public override string ToString() =>
        string.Join(Environment.NewLine, _entradas.Select(x => $"Codigo: {x.CodigoProyecto}, Nombre: {x.NombreProyecto}, Horas: {x.HorasDeTrabajo}"));
}