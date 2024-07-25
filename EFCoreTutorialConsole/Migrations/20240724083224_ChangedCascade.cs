using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTutorialConsole.Migrations
{
    public partial class ChangedCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAddresses_Students_AddressOfStudentId",
                table: "StudentAddresses");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAddresses_Students_AddressOfStudentId",
                table: "StudentAddresses",
                column: "AddressOfStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAddresses_Students_AddressOfStudentId",
                table: "StudentAddresses");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAddresses_Students_AddressOfStudentId",
                table: "StudentAddresses",
                column: "AddressOfStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
