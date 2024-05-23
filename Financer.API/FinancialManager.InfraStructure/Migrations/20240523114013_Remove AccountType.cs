using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialManager.InfraStructure.Migrations
{
    public partial class RemoveAccountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banks_AccountTypes_AccountTypeId",
                table: "Banks");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropIndex(
                name: "IX_Banks_AccountTypeId",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "Banks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                table: "Banks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banks_AccountTypeId",
                table: "Banks",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_AccountTypes_AccountTypeId",
                table: "Banks",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
