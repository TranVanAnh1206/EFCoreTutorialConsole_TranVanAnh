using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTutorialConsole.Migrations
{
    public partial class Sua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentAddresses_AddressStudentAddressId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AddressStudentAddressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AddressStudentAddressId",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressStudentAddressId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressStudentAddressId",
                table: "Students",
                column: "AddressStudentAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentAddresses_AddressStudentAddressId",
                table: "Students",
                column: "AddressStudentAddressId",
                principalTable: "StudentAddresses",
                principalColumn: "StudentAddressId");
        }
    }
}
