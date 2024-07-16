using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Gift_GiftId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gift_Categorys_CategoryId",
                table: "Gift");

            migrationBuilder.DropForeignKey(
                name: "FK_Gift_Donar_DonarId",
                table: "Gift");

            migrationBuilder.DropForeignKey(
                name: "FK_Gift_Purchase_PurchaseId",
                table: "Gift");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Gift_GiftId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Purchase_PurchaseId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Customers_CustomerId",
                table: "Purchase");

            migrationBuilder.DropTable(
                name: "Donar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owner",
                table: "Owner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gift",
                table: "Gift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys");

            migrationBuilder.RenameTable(
                name: "Purchase",
                newName: "Purchases");

            migrationBuilder.RenameTable(
                name: "Owner",
                newName: "Owners");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Gift",
                newName: "Gifts");

            migrationBuilder.RenameTable(
                name: "Categorys",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchases",
                newName: "IX_Purchases_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PurchaseId",
                table: "Orders",
                newName: "IX_Orders_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_GiftId",
                table: "Orders",
                newName: "IX_Orders_GiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Gift_PurchaseId",
                table: "Gifts",
                newName: "IX_Gifts_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Gift_DonarId",
                table: "Gifts",
                newName: "IX_Gifts_DonarId");

            migrationBuilder.RenameIndex(
                name: "IX_Gift_CategoryId",
                table: "Gifts",
                newName: "IX_Gifts_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Purchases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 3")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Gifts_GiftId",
                table: "Customers",
                column: "GiftId",
                principalTable: "Gifts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Categories_CategoryId",
                table: "Gifts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donors_DonarId",
                table: "Gifts",
                column: "DonarId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Purchases_PurchaseId",
                table: "Gifts",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Gifts_GiftId",
                table: "Orders",
                column: "GiftId",
                principalTable: "Gifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Purchases_PurchaseId",
                table: "Orders",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Customers_CustomerId",
                table: "Purchases",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Gifts_GiftId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Categories_CategoryId",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Donors_DonarId",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Purchases_PurchaseId",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Gifts_GiftId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Purchases_PurchaseId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Customers_CustomerId",
                table: "Purchases");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "Purchase");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "Owner");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Gifts",
                newName: "Gift");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorys");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_CustomerId",
                table: "Purchase",
                newName: "IX_Purchase_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PurchaseId",
                table: "Order",
                newName: "IX_Order_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_GiftId",
                table: "Order",
                newName: "IX_Order_GiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_PurchaseId",
                table: "Gift",
                newName: "IX_Gift_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_DonarId",
                table: "Gift",
                newName: "IX_Gift_DonarId");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_CategoryId",
                table: "Gift",
                newName: "IX_Gift_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Purchase",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 3");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owner",
                table: "Owner",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gift",
                table: "Gift",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Donar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donar", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Gift_GiftId",
                table: "Customers",
                column: "GiftId",
                principalTable: "Gift",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gift_Categorys_CategoryId",
                table: "Gift",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gift_Donar_DonarId",
                table: "Gift",
                column: "DonarId",
                principalTable: "Donar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gift_Purchase_PurchaseId",
                table: "Gift",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Gift_GiftId",
                table: "Order",
                column: "GiftId",
                principalTable: "Gift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Purchase_PurchaseId",
                table: "Order",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Customers_CustomerId",
                table: "Purchase",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
