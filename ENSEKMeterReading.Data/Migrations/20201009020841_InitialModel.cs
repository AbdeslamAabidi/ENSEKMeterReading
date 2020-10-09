using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ENSEKMeterReading.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "MeterReading",
                columns: table => new
                {
                    AccountId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeterReadingDateTime = table.Column<DateTime>(nullable: false),
                    MeterReadValue = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReading", x => x.AccountId);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 2344L, "Tommy", "Test" },
                    { 1246L, "Jo", "Test" },
                    { 1245L, "Neville", "Test" },
                    { 1244L, "Tony", "Test" },
                    { 1243L, "Graham", "Test" },
                    { 1242L, "Tim", "Test" },
                    { 1241L, "Lara", "Test" },
                    { 1240L, "Archie", "Test" },
                    { 1239L, "Noddy", "Test" },
                    { 1234L, "Freya", "Test" },
                    { 4534L, "JOSH", "TEST" },
                    { 6776L, "Laura", "Test" },
                    { 1247L, "Jim", "Test" },
                    { 2356L, "Craig", "Test" },
                    { 2353L, "Tony", "Test" },
                    { 2352L, "Greg", "Test" },
                    { 2351L, "Gladys", "Test" },
                    { 2350L, "Colin", "Test" },
                    { 2349L, "Simon", "Test" },
                    { 2348L, "Tammy", "Test" },
                    { 2347L, "Tara", "Test" },
                    { 2346L, "Ollie", "Test" },
                    { 2345L, "Jerry", "Test" },
                    { 8766L, "Sally", "Test" },
                    { 2233L, "Barry", "Test" },
                    { 2355L, "Arthur", "Test" },
                    { 1248L, "Pam", "Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "MeterReading");
        }
    }
}
