namespace Dispatcher.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddBlogDbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_AspNetUsers_ApplicationUserId",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameColumn(
                name: "LikeCount",
                table: "Posts",
                newName: "LikesCount");

            migrationBuilder.RenameColumn(
                name: "DislikeCount",
                table: "Posts",
                newName: "DislikesCount");

            migrationBuilder.RenameIndex(
                name: "IX_Job_IsDeleted",
                table: "Jobs",
                newName: "IX_Jobs_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Job_ApplicationUserId",
                table: "Jobs",
                newName: "IX_Jobs_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", maxLength: 100000, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_ApplicationUserId1",
                table: "Blog",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_IsDeleted",
                table: "Blog",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_ApplicationUserId",
                table: "Jobs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_ApplicationUserId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameColumn(
                name: "LikesCount",
                table: "Posts",
                newName: "LikeCount");

            migrationBuilder.RenameColumn(
                name: "DislikesCount",
                table: "Posts",
                newName: "DislikeCount");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_IsDeleted",
                table: "Job",
                newName: "IX_Job_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_ApplicationUserId",
                table: "Job",
                newName: "IX_Job_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_AspNetUsers_ApplicationUserId",
                table: "Job",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
