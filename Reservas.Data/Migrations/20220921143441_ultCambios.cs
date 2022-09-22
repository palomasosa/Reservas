using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservas.BD.Migrations
{
    public partial class ultCambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huespedes_Persona_PersonaId",
                table: "Huespedes");

            migrationBuilder.DropForeignKey(
                name: "FK_RespReservas_Persona_PersonaId",
                table: "RespReservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.RenameTable(
                name: "Persona",
                newName: "Personas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Huespedes_Personas_PersonaId",
                table: "Huespedes",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespReservas_Personas_PersonaId",
                table: "RespReservas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huespedes_Personas_PersonaId",
                table: "Huespedes");

            migrationBuilder.DropForeignKey(
                name: "FK_RespReservas_Personas_PersonaId",
                table: "RespReservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "Persona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Huespedes_Persona_PersonaId",
                table: "Huespedes",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespReservas_Persona_PersonaId",
                table: "RespReservas",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
