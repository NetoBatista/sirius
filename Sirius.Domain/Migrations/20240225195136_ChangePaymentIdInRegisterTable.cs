using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sirius.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangePaymentIdInRegisterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "register_payment_id_fkey",
                table: "register");

            migrationBuilder.AlterColumn<Guid>(
                name: "payment_id",
                table: "register",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "register_payment_id_fkey",
                table: "register",
                column: "payment_id",
                principalTable: "payment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "register_payment_id_fkey",
                table: "register");

            migrationBuilder.AlterColumn<Guid>(
                name: "payment_id",
                table: "register",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "register_payment_id_fkey",
                table: "register",
                column: "payment_id",
                principalTable: "payment",
                principalColumn: "id");
        }
    }
}
