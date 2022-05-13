namespace aysconsultores.dotnet_solid._1_Responsabilidad_Unica.SolucionMejorada;

public class Programadora : IGestorEntrada<TareaProgramada>
{
    private readonly List<TareaProgramada> _tareasProgramadas;
    public Programadora()
    {
        _tareasProgramadas = new List<TareaProgramada>();
    }
    public void AgregarEntrada(TareaProgramada entrada) => _tareasProgramadas.Add(entrada);
    public void RemoverEntradaPorIndice(int indice) => _tareasProgramadas.RemoveAt(indice);

    public override string ToString() =>
        string
            .Join(Environment.NewLine, _tareasProgramadas
            .Select(x => $"Id: {x.TareaId}, Contenido: {x.Contenido}, Ejecución: {x.EjecutarEn}"));
}
