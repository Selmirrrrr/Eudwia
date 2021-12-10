using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueLife.Server.Data.Migrations
{
    public partial class Payments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPaid_Members_MemberId",
                table: "SubscriptionPaid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPaid",
                table: "SubscriptionPaid");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                table: "SubscriptionPaid",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "MemeberId",
                table: "SubscriptionPaid",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "Members",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPaid",
                table: "SubscriptionPaid",
                columns: new[] { "MemeberId", "Year", "Month" });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPaid_MemberId",
                table: "SubscriptionPaid",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MemberId",
                table: "Payments",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPaid_Members_MemberId",
                table: "SubscriptionPaid",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPaid_Members_MemberId",
                table: "SubscriptionPaid");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPaid",
                table: "SubscriptionPaid");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionPaid_MemberId",
                table: "SubscriptionPaid");

            migrationBuilder.DropColumn(
                name: "MemeberId",
                table: "SubscriptionPaid");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Members");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                table: "SubscriptionPaid",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPaid",
                table: "SubscriptionPaid",
                columns: new[] { "MemberId", "Year", "Month" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPaid_Members_MemberId",
                table: "SubscriptionPaid",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
