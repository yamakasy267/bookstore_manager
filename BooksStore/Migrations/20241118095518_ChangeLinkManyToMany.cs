using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BooksStore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLinkManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UsersId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "GenreBooks");

            migrationBuilder.DropTable(
                name: "OrdersBooks");

            migrationBuilder.DropColumn(
                name: "Birtday",
                table: "Author");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UsersId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DatePublication",
                table: "Books",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                table: "Author",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "BooksModelGenreModel",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksModelGenreModel", x => new { x.BooksId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BooksModelGenreModel_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksModelGenreModel_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksModelOrdersModel",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "integer", nullable: false),
                    OrdersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksModelOrdersModel", x => new { x.BooksId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_BooksModelOrdersModel_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksModelOrdersModel_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksModelGenreModel_GenreId",
                table: "BooksModelGenreModel",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksModelOrdersModel_OrdersId",
                table: "BooksModelOrdersModel",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BooksModelGenreModel");

            migrationBuilder.DropTable(
                name: "BooksModelOrdersModel");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Author");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_UsersId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "Books",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birtday",
                table: "Author",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GenreBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreBooks_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersBooks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreBooks_BookId",
                table: "GenreBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreBooks_GenreId",
                table: "GenreBooks",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersBooks_BookId",
                table: "OrdersBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersBooks_OrderId",
                table: "OrdersBooks",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UsersId",
                table: "Orders",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
