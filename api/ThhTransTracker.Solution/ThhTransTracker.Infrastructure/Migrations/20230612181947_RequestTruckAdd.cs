using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThhTransTracker.Infrastructure.Migrations
{
    public partial class RequestTruckAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TruckSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f970c978-957b-43ef-b453-809f203d4b70"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("82281e5f-2633-44e6-b478-75d5f307d682"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Shippers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a9ece296-96d4-4851-9cfc-d99eb07ffa01"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("03ce6343-3c3e-4ee1-afa9-6b7fee67bbed"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8f1dcb41-7ce2-4cd2-b05a-47a2e3efcc32"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f8f37d0b-c95d-4cbb-bc5c-3b1d54d419ee"));

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipperName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OriginCity = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DestinationCity = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TruckSize = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFulfilled = table.Column<bool>(type: "bit", nullable: false),
                    CarrierClass = table.Column<int>(type: "int", nullable: false),
                    TruckNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FulfilmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAwaitingLoading = table.Column<bool>(type: "bit", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    CancelledBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancellationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLoaded = table.Column<bool>(type: "bit", nullable: false),
                    LoadingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WaybillImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMobilized = table.Column<bool>(type: "bit", nullable: false),
                    IsInTransit = table.Column<bool>(type: "bit", nullable: false),
                    IsThereEmergency = table.Column<bool>(type: "bit", nullable: false),
                    EmergencyInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentNotification = table.Column<bool>(type: "bit", nullable: false),
                    IsEmergencyResolved = table.Column<bool>(type: "bit", nullable: false),
                    ResolutionInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOffloaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOffloaded = table.Column<bool>(type: "bit", nullable: false),
                    PendingBalance = table.Column<bool>(type: "bit", nullable: false),
                    PendingWaybill = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaybillDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoadingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaybillDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaybillDetails_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaybillDetails_TransactionId",
                table: "WaybillDetails",
                column: "TransactionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaybillDetails");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TruckSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("82281e5f-2633-44e6-b478-75d5f307d682"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f970c978-957b-43ef-b453-809f203d4b70"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Shippers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("03ce6343-3c3e-4ee1-afa9-6b7fee67bbed"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a9ece296-96d4-4851-9cfc-d99eb07ffa01"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f8f37d0b-c95d-4cbb-bc5c-3b1d54d419ee"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8f1dcb41-7ce2-4cd2-b05a-47a2e3efcc32"));
        }
    }
}
