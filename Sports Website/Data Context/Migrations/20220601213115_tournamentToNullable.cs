using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Context.Migrations
{
    public partial class tournamentToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teams_tournaments_TournamentID",
                table: "teams");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentID",
                table: "teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_teams_tournaments_TournamentID",
                table: "teams",
                column: "TournamentID",
                principalTable: "tournaments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teams_tournaments_TournamentID",
                table: "teams");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentID",
                table: "teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_teams_tournaments_TournamentID",
                table: "teams",
                column: "TournamentID",
                principalTable: "tournaments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
