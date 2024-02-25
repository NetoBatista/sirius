using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sirius.Domain.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("category_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    pay_day = table.Column<int>(type: "integer", nullable: true),
                    value = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("payment_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "register",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    payment_id = table.Column<Guid>(type: "uuid", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    value = table.Column<decimal>(type: "numeric", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("register_pkey", x => x.id);
                    table.ForeignKey(
                        name: "register_category_id_fkey",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "register_payment_id_fkey",
                        column: x => x.payment_id,
                        principalTable: "payment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "category_name_key",
                table: "category",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "payment_name_key",
                table: "payment",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_register_category_id",
                table: "register",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_register_payment_id",
                table: "register",
                column: "payment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "register");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "payment");
        }
    }
}
