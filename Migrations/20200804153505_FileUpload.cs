using Microsoft.EntityFrameworkCore.Migrations;

namespace Houseplants.Migrations
{
    public partial class FileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houseplants_Galleries_GalleryHouseplantId",
                table: "Houseplants");

            migrationBuilder.DropIndex(
                name: "IX_Houseplants_GalleryHouseplantId",
                table: "Houseplants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "GalleryHouseplantId",
                table: "Houseplants");

            migrationBuilder.DropColumn(
                name: "GalleryHouseplantId",
                table: "Galleries");

            migrationBuilder.AddColumn<int>(
                name: "GalleryPictureHouseplantId",
                table: "Houseplants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PictureHouseplantId",
                table: "Galleries",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries",
                column: "PictureHouseplantId");

            migrationBuilder.CreateIndex(
                name: "IX_Houseplants_GalleryPictureHouseplantId",
                table: "Houseplants",
                column: "GalleryPictureHouseplantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houseplants_Galleries_GalleryPictureHouseplantId",
                table: "Houseplants",
                column: "GalleryPictureHouseplantId",
                principalTable: "Galleries",
                principalColumn: "PictureHouseplantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houseplants_Galleries_GalleryPictureHouseplantId",
                table: "Houseplants");

            migrationBuilder.DropIndex(
                name: "IX_Houseplants_GalleryPictureHouseplantId",
                table: "Houseplants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "GalleryPictureHouseplantId",
                table: "Houseplants");

            migrationBuilder.DropColumn(
                name: "PictureHouseplantId",
                table: "Galleries");

            migrationBuilder.AddColumn<int>(
                name: "GalleryHouseplantId",
                table: "Houseplants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GalleryHouseplantId",
                table: "Galleries",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries",
                column: "GalleryHouseplantId");

            migrationBuilder.CreateIndex(
                name: "IX_Houseplants_GalleryHouseplantId",
                table: "Houseplants",
                column: "GalleryHouseplantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houseplants_Galleries_GalleryHouseplantId",
                table: "Houseplants",
                column: "GalleryHouseplantId",
                principalTable: "Galleries",
                principalColumn: "GalleryHouseplantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
