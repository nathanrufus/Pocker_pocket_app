using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    public partial class UpdateGameModelWithDeckId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeckId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Decks",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Decks",
                column: "Id",
                value: 2);

            migrationBuilder.InsertData(
                table: "Decks",
                column: "Id",
                value: 3);

            migrationBuilder.InsertData(
                table: "Decks",
                column: "Id",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1,
                column: "DeckId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2,
                column: "DeckId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 3,
                column: "DeckId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 4,
                column: "DeckId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeckId",
                table: "Games",
                column: "DeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Decks_DeckId",
                table: "Games",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Decks_DeckId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropIndex(
                name: "IX_Games_DeckId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "Games");
        }
    }
}
