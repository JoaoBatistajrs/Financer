using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialManager.InfraStructure.Migrations
{
    public partial class DatabaseChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegisterType",
                table: "Registers",
                newName: "RegisterTypeId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Categories",
                newName: "ExpenseTypeId");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "Banks",
                newName: "AccountTypeId");

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

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registers_RegisterTypeId",
                table: "Registers",
                column: "RegisterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ExpenseTypeId",
                table: "Categories",
                column: "ExpenseTypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ExpenseTypes_ExpenseTypeId",
                table: "Categories",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_RegisterTypes_RegisterTypeId",
                table: "Registers",
                column: "RegisterTypeId",
                principalTable: "RegisterTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banks_AccountTypes_AccountTypeId",
                table: "Banks");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ExpenseTypes_ExpenseTypeId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Registers_RegisterTypes_RegisterTypeId",
                table: "Registers");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "RegisterTypes");

            migrationBuilder.DropIndex(
                name: "IX_Registers_RegisterTypeId",
                table: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ExpenseTypeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Banks_AccountTypeId",
                table: "Banks");

            migrationBuilder.RenameColumn(
                name: "RegisterTypeId",
                table: "Registers",
                newName: "RegisterType");

            migrationBuilder.RenameColumn(
                name: "ExpenseTypeId",
                table: "Categories",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AccountTypeId",
                table: "Banks",
                newName: "AccountType");
        }
    }
}
