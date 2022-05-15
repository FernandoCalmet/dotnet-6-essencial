namespace aysconsultores.dotnet_solid._4_Segregacion_Interfaces.SinAplicarPrincipio;

public class Aeroplano : IVehiculo
{
    public void Conducir()
    {
        throw new NotImplementedException();
    }

    public void Volar()
    {
        Console.WriteLine("Volar un aeroplano.");
    }
}
