using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculadoraDosificacionHormigon.Migrations
{
    /// <inheritdoc />
    public partial class INITIAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculosHormigon",
                columns: table => new
                {
                    CalculoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCalculo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cemento = table.Column<double>(type: "REAL", nullable: false),
                    Agua = table.Column<double>(type: "REAL", nullable: false),
                    Arena = table.Column<double>(type: "REAL", nullable: false),
                    Grava = table.Column<double>(type: "REAL", nullable: false),
                    VolumenTotal = table.Column<double>(type: "REAL", nullable: false),
                    RelacionAguaCemento = table.Column<double>(type: "REAL", nullable: false),
                    ResistenciaEstimada = table.Column<double>(type: "REAL", nullable: false),
                    Eliminado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculosHormigon", x => x.CalculoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculosHormigon");
        }
    }
}
