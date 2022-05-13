namespace aysconsultores.dotnet_solid._1_Responsabilidad_Unica.SolucionMejorada;

public class GuardadoArchivo
{
    public void GuardarArchivo<T>(string rutaDirectorio, string nombreArchivo, IGestorEntrada<T> informe)
    {
        if (!Directory.Exists(rutaDirectorio))
        {
            Directory.CreateDirectory(rutaDirectorio);
        }

        File.WriteAllText(Path.Combine(rutaDirectorio, nombreArchivo), informe.ToString());
    }
}
