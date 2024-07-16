using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class changeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Gifts_GiftId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Purchases_PurchaseId",
                table: "Gifts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_PurchaseId",
                table: "Gifts");

            migrationBuilder.DropIndex(
                name: "IX_Customers_GiftId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "GiftId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "GiftId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_GiftId",
                table: "Purchases",
                column: "GiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Gifts_GiftId",
                table: "Purchases",
                column: "GiftId",
                principalTable: "Gifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Gifts_GiftId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_GiftId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "GiftId",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Gifts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GiftId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "13, 31"),
                    GiftId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_PurchaseId",
                table: "Gifts",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GiftId",
                table: "Customers",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GiftId",
                table: "Orders",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PurchaseId",
                table: "Orders",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Gifts_GiftId",
                table: "Customers",
                column: "GiftId",
                principalTable: "Gifts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Purchases_PurchaseId",
                table: "Gifts",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id");
        }
    }
}
