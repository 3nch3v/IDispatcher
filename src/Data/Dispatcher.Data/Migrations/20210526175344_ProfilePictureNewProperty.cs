namespace Dispatcher.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ProfilePictureNewProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhysicalFilePath",
                table: "ProfilesPictures",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: string.Empty);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhysicalFilePath",
                table: "ProfilesPictures");
        }
    }
}
