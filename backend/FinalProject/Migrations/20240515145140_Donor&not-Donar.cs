using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class DonornotDonar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Donors_DonarId",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "DonarId",
                table: "Gifts",
                newName: "DonorId");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_DonarId",
                table: "Gifts",
                newName: "IX_Gifts_DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donors_DonorId",
                table: "Gifts",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Donors_DonorId",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "DonorId",
                table: "Gifts",
                newName: "DonarId");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_DonorId",
                table: "Gifts",
                newName: "IX_Gifts_DonarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donors_DonarId",
                table: "Gifts",
                column: "DonarId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
