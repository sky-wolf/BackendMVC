using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class personandcityandforenkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Citys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Citys_CountryId",
                table: "Citys",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citys_Countries_CountryId",
                table: "Citys",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Citys_CityId",
                table: "Persons",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citys_Countries_CountryId",
                table: "Citys");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Citys_CityId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CityId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Citys_CountryId",
                table: "Citys");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Citys");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
