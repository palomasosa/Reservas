using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservas.BD.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Huespedes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huespedes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAlojamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionAlojamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    horarioCheckIn = table.Column<int>(type: "int", nullable: false),
                    horarioCheckOut = table.Column<int>(type: "int", nullable: false),
                    totalPasajeros = table.Column<int>(type: "int", nullable: false),
                    fechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalNoches = table.Column<int>(type: "int", nullable: false),
                    fechaDeposito = table.Column<DateTime>(type: "datetime2", nullable: false),
                    montoDeposito = table.Column<int>(type: "int", nullable: false),
                    saldoRestante = table.Column<int>(type: "int", nullable: false),
                    precioTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RespReservas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespReservas", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "HuespedDNI_UQ",
                table: "Huespedes",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ReservaID_UQ",
                table: "Reservas",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RespReservaID_UQ",
                table: "RespReservas",
                column: "ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Huespedes");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "RespReservas");
        }
    }
}
