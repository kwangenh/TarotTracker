using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardId = table.Column<Guid>(nullable: false),
                    CardName = table.Column<string>(nullable: false),
                    Arcana = table.Column<int>(nullable: false),
                    Suit = table.Column<int>(nullable: true),
                    MinorNumber = table.Column<int>(nullable: true),
                    MajorNumber = table.Column<int>(nullable: true),
                    MajorName = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "ReadingType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CardCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reading",
                columns: table => new
                {
                    ReadingId = table.Column<Guid>(nullable: false),
                    ReadingDate = table.Column<DateTime>(nullable: false),
                    ReadingTypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reading", x => x.ReadingId);
                    table.ForeignKey(
                        name: "FK_Reading_ReadingType_ReadingTypeId",
                        column: x => x.ReadingTypeId,
                        principalTable: "ReadingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Reading_ReadingTypeId",
                table: "Reading",
                column: "ReadingTypeId");

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
                name: "Account");

            migrationBuilder.DropTable(
                name: "ReadingCard");

            migrationBuilder.DropTable(
                name: "Reading");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "ReadingType");
        }
    }
}
