using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.EFCore.Infra.Migrations
{
    public partial class AddedNameModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "middleName",
                table: "Names",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Names",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Names",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Names",
                newName: "middleName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Names",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Names",
                newName: "firstName");
        }
    }
}
