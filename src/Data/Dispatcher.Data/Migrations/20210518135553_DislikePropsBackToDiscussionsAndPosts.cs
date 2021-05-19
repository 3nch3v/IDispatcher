namespace Dispatcher.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DislikePropsBackToDiscussionsAndPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DislikesCount",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DislikesCount",
                table: "Discussions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DislikesCount",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DislikesCount",
                table: "Discussions");
        }
    }
}
