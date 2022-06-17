using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructureLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    LibId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.LibId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SimilaryBookId = table.Column<int>(type: "int", nullable: true),
                    BookType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryLibId = table.Column<int>(type: "int", nullable: true),
                    MainColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Books_SimilaryBookId",
                        column: x => x.SimilaryBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Libraries_LibraryLibId",
                        column: x => x.LibraryLibId,
                        principalTable: "Libraries",
                        principalColumn: "LibId");
                });

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    ReadBooksBookId = table.Column<int>(type: "int", nullable: false),
                    ReadersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.ReadBooksBookId, x.ReadersId });
                    table.ForeignKey(
                        name: "FK_BookUser_Books_ReadBooksBookId",
                        column: x => x.ReadBooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Users_ReadersId",
                        column: x => x.ReadersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryLibId",
                table: "Books",
                column: "LibraryLibId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SimilaryBookId",
                table: "Books",
                column: "SimilaryBookId",
                unique: true,
                filter: "[SimilaryBookId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_ReadersId",
                table: "BookUser",
                column: "ReadersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Libraries");
        }
    }
}
