namespace aysconsultores.dotnet_solid._1_Responsabilidad_Unica.SolucionMejorada;

public interface IGestorEntrada<T>
{
    void AgregarEntrada(T entrada);
    void RemoverEntradaPorIndice(int indice);
}
