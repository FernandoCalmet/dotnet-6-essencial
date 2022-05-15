namespace aysconsultores.dotnet_solid._4_Segregacion_Interfaces.SinAplicarPrincipio;

public class AutomovilMultiFuncional : IVehiculo
{
    public void Conducir()
    {
        Console.WriteLine("Conducir un automovil multifuncional.");
    }

    public void Volar()
    {
        Console.WriteLine("Volar un automovil multifuncional.");
    }
}
