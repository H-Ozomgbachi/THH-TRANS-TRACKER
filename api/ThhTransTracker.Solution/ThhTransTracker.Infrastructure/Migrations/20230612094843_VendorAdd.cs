using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThhTransTracker.Infrastructure.Migrations
{
    public partial class VendorAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TruckSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("89d119b5-bc36-4067-9dd8-1fde84d01f60"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("95793a78-22f7-4378-8bff-774a0fb68b4c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Shippers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cab4c6f4-62a3-412d-81f9-6506e181c9b7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6915a33c-bdb7-4e41-a6a8-9a174934a4c6"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7f75ef4e-632a-4e62-b18c-09efcd5d62c9"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("dd499662-20b1-429d-ad5b-e83d4b131002"));

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TruckSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("95793a78-22f7-4378-8bff-774a0fb68b4c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("89d119b5-bc36-4067-9dd8-1fde84d01f60"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Shippers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6915a33c-bdb7-4e41-a6a8-9a174934a4c6"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cab4c6f4-62a3-412d-81f9-6506e181c9b7"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("dd499662-20b1-429d-ad5b-e83d4b131002"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7f75ef4e-632a-4e62-b18c-09efcd5d62c9"));
        }
    }
}
