using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.EFCore.Infra.Migrations
{
    public partial class UpdatePersonModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "street",
                table: "Persons",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "religion",
                table: "Persons",
                newName: "Religion");

            migrationBuilder.RenameColumn(
                name: "relationshipStatus",
                table: "Persons",
                newName: "RelationshipStatus");

            migrationBuilder.RenameColumn(
                name: "region",
                table: "Persons",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "Persons",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "photo",
                table: "Persons",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Persons",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "nationality",
                table: "Persons",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "middleName",
                table: "Persons",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Persons",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Persons",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Persons",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Persons",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Persons",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Persons",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Persons",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "birthday",
                table: "Persons",
                newName: "Birthday");

            migrationBuilder.RenameColumn(
                name: "barangay",
                table: "Persons",
                newName: "Barangay");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Persons",
                newName: "Age");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Persons",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "Religion",
                table: "Persons",
                newName: "religion");

            migrationBuilder.RenameColumn(
                name: "RelationshipStatus",
                table: "Persons",
                newName: "relationshipStatus");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Persons",
                newName: "region");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Persons",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Persons",
                newName: "photo");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Persons",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Persons",
                newName: "nationality");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Persons",
                newName: "middleName");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Persons",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Persons",
                newName: "latitude");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Persons",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Persons",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Persons",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Persons",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Persons",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Persons",
                newName: "birthday");

            migrationBuilder.RenameColumn(
                name: "Barangay",
                table: "Persons",
                newName: "barangay");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Persons",
                newName: "age");
        }
    }
}
