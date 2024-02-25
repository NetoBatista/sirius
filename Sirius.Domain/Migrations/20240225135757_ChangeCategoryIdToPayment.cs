using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sirius.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCategoryIdToPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "register_category_id_fkey",
                table: "register");

            migrationBuilder.DropIndex(
                name: "IX_register_category_id",
                table: "register");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "register");

            migrationBuilder.AddColumn<Guid>(
                name: "category_id",
                table: "payment",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_payment_category_id",
                table: "payment",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "payment_category_id_fkey",
                table: "payment",
                column: "category_id",
                principalTable: "category",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "payment_category_id_fkey",
                table: "payment");

            migrationBuilder.DropIndex(
                name: "IX_payment_category_id",
                table: "payment");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "payment");

            migrationBuilder.AddColumn<Guid>(
                name: "category_id",
                table: "register",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_register_category_id",
                table: "register",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "register_category_id_fkey",
                table: "register",
                column: "category_id",
                principalTable: "category",
                principalColumn: "id");
        }
    }
}
