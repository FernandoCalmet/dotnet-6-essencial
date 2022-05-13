namespace aysconsultores.dotnet_solid._1_Responsabilidad_Unica.AplicandoPrincipio;

public class GuardadoArchivo
{
    public void GuardarArchivo(string rutaDirectorio, string nombreArchivo, InformeTrabajo informe)
    {
        if (!Directory.Exists(rutaDirectorio))
        {
            Directory.CreateDirectory(rutaDirectorio);
        }

        File.WriteAllText(Path.Combine(rutaDirectorio, nombreArchivo), informe.ToString());
    }
}
