using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class updatereferens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citys_Countries_CountryId",
                table: "Citys");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguagePersonDB_Languages_LanguageId",
                table: "LanguagePersonDB");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguagePersonDB_Persons_PersonId",
                table: "LanguagePersonDB");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Citys_CityId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Citys",
                table: "Citys");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "People");

            migrationBuilder.RenameTable(
                name: "Citys",
                newName: "Cities");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "LanguagePersonDB",
                newName: "PeopleId");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "LanguagePersonDB",
                newName: "LanguagesId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguagePersonDB_PersonId",
                table: "LanguagePersonDB",
                newName: "IX_LanguagePersonDB_PeopleId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_CityId",
                table: "People",
                newName: "IX_People_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Citys_CountryId",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CityId",
                table: "Languages",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguagePersonDB_Languages_LanguagesId",
                table: "LanguagePersonDB",
                column: "LanguagesId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguagePersonDB_People_PeopleId",
                table: "LanguagePersonDB",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Cities_CityId",
                table: "Languages",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguagePersonDB_Languages_LanguagesId",
                table: "LanguagePersonDB");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguagePersonDB_People_PeopleId",
                table: "LanguagePersonDB");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Cities_CityId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Languages_CityId",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "Citys");

            migrationBuilder.RenameColumn(
                name: "PeopleId",
                table: "LanguagePersonDB",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "LanguagesId",
                table: "LanguagePersonDB",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguagePersonDB_PeopleId",
                table: "LanguagePersonDB",
                newName: "IX_LanguagePersonDB_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_People_CityId",
                table: "Persons",
                newName: "IX_Persons_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "Citys",
                newName: "IX_Citys_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Citys",
                table: "Citys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Citys_Countries_CountryId",
                table: "Citys",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguagePersonDB_Languages_LanguageId",
                table: "LanguagePersonDB",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguagePersonDB_Persons_PersonId",
                table: "LanguagePersonDB",
                column: "PersonId",
                principalTable: "Persons",
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
    }
}
