using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservas.BD.Migrations
{
    public partial class persona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alojamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAlojamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionAlojamiento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Huespedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huespedes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huespedes_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RespReservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespReservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespReservas_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horarioCheckIn = table.Column<int>(type: "int", nullable: false),
                    horarioCheckOut = table.Column<int>(type: "int", nullable: false),
                    totalPasajeros = table.Column<int>(type: "int", nullable: false),
                    fechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalNoches = table.Column<int>(type: "int", nullable: false),
                    fechaDeposito = table.Column<DateTime>(type: "datetime2", nullable: false),
                    montoDeposito = table.Column<int>(type: "int", nullable: false),
                    saldoRestante = table.Column<int>(type: "int", nullable: false),
                    precioTotal = table.Column<int>(type: "int", nullable: false),
                    HuespedId = table.Column<int>(type: "int", nullable: false),
                    RespReservaId = table.Column<int>(type: "int", nullable: false),
                    AlojamientoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Alojamientos_AlojamientoId",
                        column: x => x.AlojamientoId,
                        principalTable: "Alojamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Huespedes_HuespedId",
                        column: x => x.HuespedId,
                        principalTable: "Huespedes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_RespReservas_RespReservaId",
                        column: x => x.RespReservaId,
                        principalTable: "RespReservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "AlojamientoID_UQ",
                table: "Alojamientos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PersonaId_UQ",
                table: "Huespedes",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AlojamientoId",
                table: "Reservas",
                column: "AlojamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_HuespedId",
                table: "Reservas",
                column: "HuespedId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_RespReservaId",
                table: "Reservas",
                column: "RespReservaId");

            migrationBuilder.CreateIndex(
                name: "ReservaID_UQ",
                table: "Reservas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PersonaId_UQ1",
                table: "RespReservas",
                column: "PersonaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Alojamientos");

            migrationBuilder.DropTable(
                name: "Huespedes");

            migrationBuilder.DropTable(
                name: "RespReservas");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
