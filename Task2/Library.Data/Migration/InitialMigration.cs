using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "RentEvents");

            migrationBuilder.DropTable(
                "ReturnEvents");

            migrationBuilder.DropTable(
                "States");

            migrationBuilder.DropTable(
                "Clients");

            migrationBuilder.DropTable(
                "BookDictionary");

            migrationBuilder.DropTable(
                "Books");

            migrationBuilder.DropTable(
                "BookCatalogs");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "BookCatalogs",
                table => new
                {
                    CatalogId = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table => { table.PrimaryKey("PK_BookCatalogs", x => x.CatalogId); });

            migrationBuilder.CreateTable(
                "Clients",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    AmountOfBooksRented = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_Clients", x => x.Id); });

            migrationBuilder.CreateTable(
                "Books",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(nullable: true),
                    BookGenre = table.Column<int>(),
                    Title = table.Column<string>(nullable: true),
                    BookCatalogCatalogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        "FK_Books_BookCatalogs_BookCatalogCatalogId",
                        x => x.BookCatalogCatalogId,
                        "BookCatalogs",
                        "CatalogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "BookDictionary",
                table => new
                {
                    DictionaryId = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: true),
                    BooksAmount = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDictionary", x => x.DictionaryId);
                    table.ForeignKey(
                        "FK_BookDictionary_Books_BookId",
                        x => x.BookId,
                        "Books",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "States",
                table => new
                {
                    StateId = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllBooksCatalogId = table.Column<int>(nullable: true),
                    AvailableBooksDictionaryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                    table.ForeignKey(
                        "FK_States_BookCatalogs_AllBooksCatalogId",
                        x => x.AllBooksCatalogId,
                        "BookCatalogs",
                        "CatalogId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_States_BookDictionary_AvailableBooksDictionaryId",
                        x => x.AvailableBooksDictionaryId,
                        "BookDictionary",
                        "DictionaryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "RentEvents",
                table => new
                {
                    EventId = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(),
                    BookId = table.Column<int>(),
                    EventDate = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentEvents", x => x.EventId);
                    table.ForeignKey(
                        "FK_RentEvents_States_BookId",
                        x => x.BookId,
                        "States",
                        "StateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_RentEvents_Clients_UserId",
                        x => x.UserId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ReturnEvents",
                table => new
                {
                    EventId = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(),
                    BookId = table.Column<int>(),
                    EventDate = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnEvents", x => x.EventId);
                    table.ForeignKey(
                        "FK_ReturnEvents_States_BookId",
                        x => x.BookId,
                        "States",
                        "StateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ReturnEvents_Clients_UserId",
                        x => x.UserId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_BookDictionary_BookId",
                "BookDictionary",
                "BookId");

            migrationBuilder.CreateIndex(
                "IX_Books_BookCatalogCatalogId",
                "Books",
                "BookCatalogCatalogId");

            migrationBuilder.CreateIndex(
                "IX_States_AllBooksCatalogId",
                "States",
                "AllBooksCatalogId");

            migrationBuilder.CreateIndex(
                "IX_States_AvailableBooksDictionaryId",
                "States",
                "AvailableBooksDictionaryId");

            migrationBuilder.CreateIndex(
                "IX_RentEvents_BookId",
                "RentEvents",
                "BookId");

            migrationBuilder.CreateIndex(
                "IX_RentEvents_UserId",
                "RentEvents",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_ReturnEvents_BookId",
                "ReturnEvents",
                "BookId");

            migrationBuilder.CreateIndex(
                "IX_ReturnEvents_UserId",
                "ReturnEvents",
                "UserId");
        }
    }
}