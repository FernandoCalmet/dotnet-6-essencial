namespace aysconsultores.dotnet_solid._4_Segregacion_Interfaces.SinAplicarPrincipio;

public class Automovil : IVehiculo
{
    public void Conducir()
    {
        Console.WriteLine("Conducir un automovil.");
    }

    public void Volar()
    {
        throw new NotImplementedException();
    }
}
