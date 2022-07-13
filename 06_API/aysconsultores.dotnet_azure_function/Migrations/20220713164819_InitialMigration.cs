using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aysconsultores.dotnet_azure_function.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "LastName", "Password", "Username" },
                values: new object[] { 1, "fernando.calmet@aysconsultores.pe", "Fernando", (byte)1, "Calmet", "12345678", "fcalmet" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "LastName", "Password", "Username" },
                values: new object[] { 2, "maria.injante@aysconsultores.pe", "Maria", (byte)2, "Injante", "12345678", "minjante" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "LastName", "Password", "Username" },
                values: new object[] { 3, "carlos.perez@aysconsultores.pe", "Carlos", (byte)1, "Perez", "12345678", "cperez" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
