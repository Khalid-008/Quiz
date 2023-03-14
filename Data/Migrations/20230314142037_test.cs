using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_Store_id",
                table: "Employees",
                column: "Store_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Stores_Store_id",
                table: "Employees",
                column: "Store_id",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Stores_Store_id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Store_id",
                table: "Employees");
        }
    }
}
