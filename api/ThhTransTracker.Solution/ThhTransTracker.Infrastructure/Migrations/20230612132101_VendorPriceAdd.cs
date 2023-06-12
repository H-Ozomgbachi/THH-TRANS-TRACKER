using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThhTransTracker.Infrastructure.Migrations
{
    public partial class VendorPriceAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TruckSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("82281e5f-2633-44e6-b478-75d5f307d682"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("89d119b5-bc36-4067-9dd8-1fde84d01f60"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Shippers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("03ce6343-3c3e-4ee1-afa9-6b7fee67bbed"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cab4c6f4-62a3-412d-81f9-6506e181c9b7"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f8f37d0b-c95d-4cbb-bc5c-3b1d54d419ee"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7f75ef4e-632a-4e62-b18c-09efcd5d62c9"));

            migrationBuilder.CreateTable(
                name: "VendorPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DestinationCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TruckSize = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorPrices_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendorPrices_VendorId",
                table: "VendorPrices",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendorPrices");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TruckSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("89d119b5-bc36-4067-9dd8-1fde84d01f60"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("82281e5f-2633-44e6-b478-75d5f307d682"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Shippers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cab4c6f4-62a3-412d-81f9-6506e181c9b7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("03ce6343-3c3e-4ee1-afa9-6b7fee67bbed"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7f75ef4e-632a-4e62-b18c-09efcd5d62c9"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f8f37d0b-c95d-4cbb-bc5c-3b1d54d419ee"));
        }
    }
}
