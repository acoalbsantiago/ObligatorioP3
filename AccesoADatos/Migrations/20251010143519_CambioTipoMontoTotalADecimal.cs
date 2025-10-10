using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoADatos.Migrations
{
    /// <inheritdoc />
    public partial class CambioTipoMontoTotalADecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MontoTotal",
                table: "pagos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MontoTotal",
                table: "pagos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
