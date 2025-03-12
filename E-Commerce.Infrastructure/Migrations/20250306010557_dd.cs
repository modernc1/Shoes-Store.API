using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistory_Orders_OrderId",
                table: "CheckoutHistory");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "CheckoutHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistory_Orders_OrderId",
                table: "CheckoutHistory",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistory_Orders_OrderId",
                table: "CheckoutHistory");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "CheckoutHistory",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistory_Orders_OrderId",
                table: "CheckoutHistory",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
