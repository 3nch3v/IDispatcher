namespace Dispatcher.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class BlogDbModelPropertiesChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureFileName",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Blogs",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalFilePath",
                table: "Blogs",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: string.Empty);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "PhysicalFilePath",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "PictureFileName",
                table: "Blogs",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);
        }
    }
}
