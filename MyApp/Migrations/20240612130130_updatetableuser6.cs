using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    public partial class updatetableuser6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Balance",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BetAmount",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentBetAmount",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentPlayerIndex",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pot",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameModelGameId",
                table: "CardModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardModel_GameModelGameId",
                table: "CardModel",
                column: "GameModelGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardModel_Games_GameModelGameId",
                table: "CardModel",
                column: "GameModelGameId",
                principalTable: "Games",
                principalColumn: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardModel_Games_GameModelGameId",
                table: "CardModel");

            migrationBuilder.DropIndex(
                name: "IX_CardModel_GameModelGameId",
                table: "CardModel");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "BetAmount",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CurrentBetAmount",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CurrentPlayerIndex",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Pot",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameModelGameId",
                table: "CardModel");
        }
    }
}
