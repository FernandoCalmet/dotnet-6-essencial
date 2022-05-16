using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aysconsultores.dotnet_web_api_minimal.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "Id", "Contenido", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { 1, "Contenido de Articulo 1", new DateTime(2022, 5, 16, 22, 50, 6, 739, DateTimeKind.Utc).AddTicks(6128), "Articulo 1" },
                    { 2, "Contenido de Articulo 2", new DateTime(2022, 5, 16, 22, 50, 6, 739, DateTimeKind.Utc).AddTicks(6131), "Articulo 2" },
                    { 3, "Contenido de Articulo 3", new DateTime(2022, 5, 16, 22, 50, 6, 739, DateTimeKind.Utc).AddTicks(6131), "Articulo 3" },
                    { 4, "Contenido de Articulo 4", new DateTime(2022, 5, 16, 22, 50, 6, 739, DateTimeKind.Utc).AddTicks(6132), "Articulo 4" },
                    { 5, "Contenido de Articulo 5", new DateTime(2022, 5, 16, 22, 50, 6, 739, DateTimeKind.Utc).AddTicks(6133), "Articulo 5" },
                    { 6, "Contenido de Articulo 6", new DateTime(2022, 5, 16, 22, 50, 6, 739, DateTimeKind.Utc).AddTicks(6133), "Articulo 6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");
        }
    }
}
