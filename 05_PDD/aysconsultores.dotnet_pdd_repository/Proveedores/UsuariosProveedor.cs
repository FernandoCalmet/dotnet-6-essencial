using aysconsultores.dotnet_pdd_repository.Entidades;

namespace aysconsultores.dotnet_pdd_repository.Proveedores;

public class UsuariosProveedor
{
    public List<Usuario> Usuarios { get; set; }

    public UsuariosProveedor()
    {
        Usuarios = new();

        Usuarios.Add(new Usuario
        {
            UsuarioId = new Guid("ae9879fa-ebbb-4d3f-b721-8e9996472bc5"),
            Nombre = "Fernando",
            FechaNacimiento = new DateOnly(1989, 9, 6)
        });
        Usuarios.Add(new Usuario
        {
            UsuarioId = new Guid("623081d9-9837-4198-a5d8-1a08a6298e33"),
            Nombre = "Sofia",
            FechaNacimiento = new DateOnly(1998, 2, 12)
        });
        Usuarios.Add(new Usuario
        {
            UsuarioId = new Guid("8b3198f6-996c-4c67-b96a-943aa12ebd05"),
            Nombre = "Mario",
            FechaNacimiento = new DateOnly(1980, 11, 23)
        });
        Usuarios.Add(new Usuario
        {
            UsuarioId = new Guid("bcc06239-a396-41b9-8ba6-04f1a1b0796d"),
            Nombre = "Miguel",
            FechaNacimiento = new DateOnly(2000, 5, 5)
        });
        Usuarios.Add(new Usuario
        {
            UsuarioId = new Guid("fee2f251-7508-43fe-a2e2-25d0add6d4fc"),
            Nombre = "Andrea",
            FechaNacimiento = new DateOnly(1995, 10, 5)
        });
    }
}
