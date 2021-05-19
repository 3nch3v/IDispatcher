using Microsoft.EntityFrameworkCore.Migrations;

namespace Dispatcher.Data.Migrations
{
    public partial class DbChangesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LikesCount",
                table: "Votes",
                newName: "Like");

            migrationBuilder.RenameColumn(
                name: "DislikesCount",
                table: "Votes",
                newName: "Dislike");

            migrationBuilder.AlterColumn<int>(
                name: "DiscussionId",
                table: "Votes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Like",
                table: "Votes",
                newName: "LikesCount");

            migrationBuilder.RenameColumn(
                name: "Dislike",
                table: "Votes",
                newName: "DislikesCount");

            migrationBuilder.AlterColumn<int>(
                name: "DiscussionId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
