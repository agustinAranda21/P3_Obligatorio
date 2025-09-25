using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessDataLogic.Migrations
{
    /// <inheritdoc />
    public partial class cambioEstructuraAuditoriaTipoGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTipoGasto",
                table: "auditoriasTipoGastos");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "auditoriasTipoGastos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "auditoriasTipoGastos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Accion",
                table: "auditoriasTipoGastos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "auditoriasTipoGastos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "auditoriasTipoGastos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "auditoriasTipoGastos");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "auditoriasTipoGastos");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "auditoriasTipoGastos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "auditoriasTipoGastos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Accion",
                table: "auditoriasTipoGastos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoGasto",
                table: "auditoriasTipoGastos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
