using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservas.BD.Migrations
{
    public partial class cambioDatoDNI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Telefono",
                table: "Personas",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "Huespedes",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefono",
                table: "Personas",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "DNI",
                table: "Huespedes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);
        }
    }
}
