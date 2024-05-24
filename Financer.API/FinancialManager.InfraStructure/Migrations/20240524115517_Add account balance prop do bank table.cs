using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialManager.InfraStructure.Migrations
{
    public partial class Addaccountbalancepropdobanktable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AccountBalance",
                table: "Banks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountBalance",
                table: "Banks");
        }
    }
}
