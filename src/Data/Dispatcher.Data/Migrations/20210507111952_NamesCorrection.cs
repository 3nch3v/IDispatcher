namespace Dispatcher.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class NamesCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_AspNetUsers_ApplicationUserId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_AspNetUsers_ApplicationUserId1",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersReviews_AspNetUsers_ApplicationUserId",
                table: "CustomersReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_ApplicationUserId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ApplicationUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_MessagesRecipients_AspNetUsers_ApplicationUserId",
                table: "MessagesRecipients");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ApplicationUserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDiscussions_AspNetUsers_ApplicationUserId",
                table: "UsersDiscussions");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGroups_AspNetUsers_ApplicationUserId",
                table: "UsersGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Contacts",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Blogs");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "UsersGroups",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersGroups_ApplicationUserId",
                table: "UsersGroups",
                newName: "IX_UsersGroups_UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "UsersDiscussions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Projects",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ApplicationUserId",
                table: "Projects",
                newName: "IX_Projects_UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Posts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ApplicationUserId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "MessagesRecipients",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MessagesRecipients_ApplicationUserId",
                table: "MessagesRecipients",
                newName: "IX_MessagesRecipients_UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ApplicationUserId",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Jobs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_ApplicationUserId",
                table: "Jobs",
                newName: "IX_Jobs_UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "CustomersReviews",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomersReviews_ApplicationUserId",
                table: "CustomersReviews",
                newName: "IX_CustomersReviews_UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Advertisements",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisements_ApplicationUserId",
                table: "Advertisements",
                newName: "IX_Advertisements_UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId1",
                table: "Blogs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_IsDeleted",
                table: "Blogs",
                newName: "IX_Blogs_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_ApplicationUserId1",
                table: "Blogs",
                newName: "IX_Blogs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_AspNetUsers_UserId",
                table: "Advertisements",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersReviews_AspNetUsers_UserId",
                table: "CustomersReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_UserId",
                table: "Jobs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesRecipients_AspNetUsers_UserId",
                table: "MessagesRecipients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDiscussions_AspNetUsers_UserId",
                table: "UsersDiscussions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGroups_AspNetUsers_UserId",
                table: "UsersGroups",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_AspNetUsers_UserId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_UserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersReviews_AspNetUsers_UserId",
                table: "CustomersReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_UserId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_MessagesRecipients_AspNetUsers_UserId",
                table: "MessagesRecipients");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_UserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDiscussions_AspNetUsers_UserId",
                table: "UsersDiscussions");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGroups_AspNetUsers_UserId",
                table: "UsersGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blog");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UsersGroups",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersGroups_UserId",
                table: "UsersGroups",
                newName: "IX_UsersGroups_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UsersDiscussions",
                newName: "ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Projects",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                newName: "IX_Projects_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Posts",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                newName: "IX_Posts_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MessagesRecipients",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MessagesRecipients_UserId",
                table: "MessagesRecipients",
                newName: "IX_MessagesRecipients_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                newName: "IX_Messages_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Jobs",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_UserId",
                table: "Jobs",
                newName: "IX_Jobs_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CustomersReviews",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomersReviews_UserId",
                table: "CustomersReviews",
                newName: "IX_CustomersReviews_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Advertisements",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisements_UserId",
                table: "Advertisements",
                newName: "IX_Advertisements_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Blog",
                newName: "ApplicationUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_UserId",
                table: "Blog",
                newName: "IX_Blog_ApplicationUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_IsDeleted",
                table: "Blog",
                newName: "IX_Blog_IsDeleted");

            migrationBuilder.AddColumn<string>(
                name: "Contacts",
                table: "AspNetUsers",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "AspNetUsers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_AspNetUsers_ApplicationUserId",
                table: "Advertisements",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_AspNetUsers_ApplicationUserId1",
                table: "Blog",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersReviews_AspNetUsers_ApplicationUserId",
                table: "CustomersReviews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_ApplicationUserId",
                table: "Jobs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ApplicationUserId",
                table: "Messages",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesRecipients_AspNetUsers_ApplicationUserId",
                table: "MessagesRecipients",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ApplicationUserId",
                table: "Projects",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDiscussions_AspNetUsers_ApplicationUserId",
                table: "UsersDiscussions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGroups_AspNetUsers_ApplicationUserId",
                table: "UsersGroups",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
