using aysconsultores.dotnet_pdd_repository.Entidades;

namespace aysconsultores.dotnet_pdd_repository.Proveedores;

public class CuentasProveedor
{
    public List<Cuenta> Cuentas { get; set; }

    public CuentasProveedor()
    {
        Cuentas = new();

        Cuentas.Add(new Cuenta
        {
            CuentaId = new Guid("ae9879fa-ebbb-4d3f-b721-8e9996472bc6"),
            FechaRegistro = DateTime.Now,
            TipoCuenta = "Credito",
            Saldo = 1005.50,
            UsuarioId = new Guid("ae9879fa-ebbb-4d3f-b721-8e9996472bc5")
        });
        Cuentas.Add(new Cuenta
        {
            CuentaId = new Guid("623081d9-9837-4198-a5d8-1a08a6298e34"),
            FechaRegistro = DateTime.Now,
            TipoCuenta = "Ahorros",
            Saldo = 505.20,
            UsuarioId = new Guid("623081d9-9837-4198-a5d8-1a08a6298e33")
        });
        Cuentas.Add(new Cuenta
        {
            CuentaId = new Guid("8b3198f6-996c-4c67-b96a-943aa12ebd06"),
            FechaRegistro = DateTime.Now,
            TipoCuenta = "Credito",
            Saldo = 235.25,
            UsuarioId = new Guid("8b3198f6-996c-4c67-b96a-943aa12ebd05")
        });
        Cuentas.Add(new Cuenta
        {
            CuentaId = new Guid("bcc06239-a396-41b9-8ba6-04f1a1b0797d"),
            FechaRegistro = DateTime.Now,
            TipoCuenta = "Ahorros",
            Saldo = 105.00,
            UsuarioId = new Guid("bcc06239-a396-41b9-8ba6-04f1a1b0796d")
        });
        Cuentas.Add(new Cuenta
        {
            CuentaId = new Guid("fee2f251-7508-43fe-a2e2-25d0add6d5fc"),
            FechaRegistro = DateTime.Now,
            TipoCuenta = "Ahorros",
            Saldo = 35.50,
            UsuarioId = new Guid("fee2f251-7508-43fe-a2e2-25d0add6d4fc")
        });
    }
}
