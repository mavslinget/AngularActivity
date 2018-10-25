using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.EFCore.Infra.Migrations
{
    public partial class AddedPersonModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<Guid>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    middleName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    birthday = table.Column<DateTime>(nullable: false),
                    photo = table.Column<byte[]>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    relationshipStatus = table.Column<string>(nullable: true),
                    nationality = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    religion = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    barangay = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    postalCode = table.Column<int>(nullable: false),
                    latitude = table.Column<decimal>(nullable: false),
                    longitude = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
