using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThhTransTracker.Infrastructure.Migrations
{
    public partial class ShipperPriceAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TruckSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("95793a78-22f7-4378-8bff-774a0fb68b4c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e9d231c5-86e5-4a1a-9811-85cdd5fdccae"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Shippers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6915a33c-bdb7-4e41-a6a8-9a174934a4c6"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("1b89eedf-d0a2-432c-be8f-cb4a7cff3fd8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("dd499662-20b1-429d-ad5b-e83d4b131002"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c0a821be-7110-4f9b-a618-183fd3c0a22f"));

            migrationBuilder.CreateTable(
                name: "ShipperPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DestinationCity = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TruckSize = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipperPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipperPrices_Shippers_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "Shippers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShipperPrices_ShipperId",
                table: "ShipperPrices",
                column: "ShipperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipperPrices");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TruckSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e9d231c5-86e5-4a1a-9811-85cdd5fdccae"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("95793a78-22f7-4378-8bff-774a0fb68b4c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Shippers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("1b89eedf-d0a2-432c-be8f-cb4a7cff3fd8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6915a33c-bdb7-4e41-a6a8-9a174934a4c6"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c0a821be-7110-4f9b-a618-183fd3c0a22f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("dd499662-20b1-429d-ad5b-e83d4b131002"));
        }
    }
}
