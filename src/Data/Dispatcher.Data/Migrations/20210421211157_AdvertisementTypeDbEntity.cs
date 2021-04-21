using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dispatcher.Data.Migrations
{
    public partial class AdvertisementTypeDbEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Аdvertisements_АdvertisementId1",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Аdvertisements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_АdvertisementId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "АdvertisementId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "АdvertisementId1",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "ApplicationUserId", "AdvertisementId" });

            migrationBuilder.CreateTable(
                name: "AdvertisementType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementTypeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Compensation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Like = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisements_AdvertisementType_AdvertisementTypeId",
                        column: x => x.AdvertisementTypeId,
                        principalTable: "AdvertisementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advertisements_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AdvertisementId",
                table: "Comments",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AdvertisementTypeId",
                table: "Advertisements",
                column: "AdvertisementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_ApplicationUserId",
                table: "Advertisements",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_IsDeleted",
                table: "Advertisements",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Advertisements_AdvertisementId",
                table: "Comments",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Advertisements_AdvertisementId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "AdvertisementType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AdvertisementId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "АdvertisementId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "АdvertisementId1",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "ApplicationUserId", "АdvertisementId" });

            migrationBuilder.CreateTable(
                name: "Аdvertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Compensation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Like = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    АdvertisementType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Аdvertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Аdvertisements_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_АdvertisementId1",
                table: "Comments",
                column: "АdvertisementId1");

            migrationBuilder.CreateIndex(
                name: "IX_Аdvertisements_ApplicationUserId",
                table: "Аdvertisements",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Аdvertisements_IsDeleted",
                table: "Аdvertisements",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Аdvertisements_АdvertisementId1",
                table: "Comments",
                column: "АdvertisementId1",
                principalTable: "Аdvertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
