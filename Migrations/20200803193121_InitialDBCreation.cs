using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Houseplants.Migrations
{
    public partial class InitialDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    GalleryHouseplantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.GalleryHouseplantId);
                });

            migrationBuilder.CreateTable(
                name: "Houseplants",
                columns: table => new
                {
                    HouseplantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NameLatin = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<byte[]>(nullable: true),
                    GalleryHouseplantId = table.Column<int>(nullable: true),
                    BuyDate = table.Column<DateTime>(nullable: false),
                    LastPlantDate = table.Column<DateTime>(nullable: false),
                    PlaceName = table.Column<string>(nullable: true),
                    IrrigationDescription = table.Column<string>(nullable: true),
                    Fertigation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houseplants", x => x.HouseplantId);
                    table.ForeignKey(
                        name: "FK_Houseplants_Galleries_GalleryHouseplantId",
                        column: x => x.GalleryHouseplantId,
                        principalTable: "Galleries",
                        principalColumn: "GalleryHouseplantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Houseplants_GalleryHouseplantId",
                table: "Houseplants",
                column: "GalleryHouseplantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houseplants");

            migrationBuilder.DropTable(
                name: "Galleries");
        }
    }
}
