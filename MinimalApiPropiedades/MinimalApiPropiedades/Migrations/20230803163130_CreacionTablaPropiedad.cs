using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalApiPropiedades.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablaPropiedad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propiedad",
                columns: table => new
                {
                    IdPropiedad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedad", x => x.IdPropiedad);
                });

            migrationBuilder.InsertData(
                table: "Propiedad",
                columns: new[] { "IdPropiedad", "Activa", "Descripcion", "FechaCreacion", "Nombre", "Ubicacion" },
                values: new object[,]
                {
                    { 1, true, "Descripción test", new DateTime(2023, 8, 3, 18, 31, 30, 832, DateTimeKind.Local).AddTicks(599), "Casa las palmas", "Cartagena" },
                    { 2, true, "Descripción test", new DateTime(2023, 8, 3, 18, 31, 30, 832, DateTimeKind.Local).AddTicks(647), "Casa las flores", "Asturias" },
                    { 3, false, "Descripción test", new DateTime(2023, 8, 3, 18, 31, 30, 832, DateTimeKind.Local).AddTicks(650), "Casa las castañas", "Galicia" },
                    { 4, true, "Descripción test", new DateTime(2023, 8, 3, 18, 31, 30, 832, DateTimeKind.Local).AddTicks(652), "Casa las peras", "Madrid" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propiedad");
        }
    }
}
