using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessDataLogic.Migrations
{
    /// <inheritdoc />
    public partial class hojfs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idTipoGasto",
                table: "auditoriasTipoGastos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idTipoGasto",
                table: "auditoriasTipoGastos");
        }
    }
}
