using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class initialCrete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardId = table.Column<Guid>(nullable: false),
                    CardName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Reading",
                columns: table => new
                {
                    ReadingId = table.Column<Guid>(nullable: false),
                    ReadingType = table.Column<string>(nullable: true),
                    ReadingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reading", x => x.ReadingId);
                });

            migrationBuilder.CreateTable(
                name: "ReadingCard",
                columns: table => new
                {
                    ReadingCardId = table.Column<Guid>(nullable: false),
                    ReadCardCardId = table.Column<Guid>(nullable: true),
                    CardReadingReadingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingCard", x => x.ReadingCardId);
                    table.ForeignKey(
                        name: "FK_ReadingCard_Reading_CardReadingReadingId",
                        column: x => x.CardReadingReadingId,
                        principalTable: "Reading",
                        principalColumn: "ReadingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReadingCard_Card_ReadCardCardId",
                        column: x => x.ReadCardCardId,
                        principalTable: "Card",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReadingCard_CardReadingReadingId",
                table: "ReadingCard",
                column: "CardReadingReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingCard_ReadCardCardId",
                table: "ReadingCard",
                column: "ReadCardCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ReadingCard");

            migrationBuilder.DropTable(
                name: "Reading");

            migrationBuilder.DropTable(
                name: "Card");
        }
    }
}
