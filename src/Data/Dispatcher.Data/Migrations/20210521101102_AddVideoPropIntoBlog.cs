namespace Dispatcher.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddVideoPropIntoBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RemotePictureUrl",
                table: "Blogs",
                newName: "VideoLink");

            migrationBuilder.AddColumn<string>(
                name: "PictureFileName",
                table: "Blogs",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureFileName",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "VideoLink",
                table: "Blogs",
                newName: "RemotePictureUrl");
        }
    }
}
