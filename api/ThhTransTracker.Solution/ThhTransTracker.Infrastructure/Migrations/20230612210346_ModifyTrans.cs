using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThhTransTracker.Infrastructure.Migrations
{
    public partial class ModifyTrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TruckSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e5778804-a57b-45f9-8cc8-9b2844701c33"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f970c978-957b-43ef-b453-809f203d4b70"));

            migrationBuilder.AddColumn<string>(
                name: "InvestorName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Shippers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ecb72d3f-22fa-4b82-aa89-6f7a98d9aeb0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a9ece296-96d4-4851-9cfc-d99eb07ffa01"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("04540bad-dd40-423c-baa1-135ae8da4e69"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8f1dcb41-7ce2-4cd2-b05a-47a2e3efcc32"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvestorName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "VendorName",
                table: "Transactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TruckSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f970c978-957b-43ef-b453-809f203d4b70"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e5778804-a57b-45f9-8cc8-9b2844701c33"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Shippers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a9ece296-96d4-4851-9cfc-d99eb07ffa01"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ecb72d3f-22fa-4b82-aa89-6f7a98d9aeb0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8f1dcb41-7ce2-4cd2-b05a-47a2e3efcc32"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("04540bad-dd40-423c-baa1-135ae8da4e69"));
        }
    }
}
