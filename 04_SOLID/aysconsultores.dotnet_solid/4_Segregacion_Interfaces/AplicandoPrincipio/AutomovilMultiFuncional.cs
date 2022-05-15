namespace aysconsultores.dotnet_solid._4_Segregacion_Interfaces.AplicandoPrincipio;

public class AutomovilMultiFuncional : IAutomovilMultiFuncional
{
    public void Conducir()
    {
        Console.WriteLine("Conducir automovil multifuncional");
    }

    public void Volar()
    {
        Console.WriteLine("Volar automovil multifuncional");
    }
}
