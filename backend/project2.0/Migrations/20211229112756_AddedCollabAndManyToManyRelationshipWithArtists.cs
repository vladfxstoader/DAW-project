using Microsoft.EntityFrameworkCore.Migrations;

namespace project2._0.Migrations
{
    public partial class AddedCollabAndManyToManyRelationshipWithArtists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollabArtists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    CollabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollabArtists", x => new { x.ArtistId, x.CollabId });
                    table.ForeignKey(
                        name: "FK_CollabArtists_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollabArtists_Collabs_CollabId",
                        column: x => x.CollabId,
                        principalTable: "Collabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollabArtists_CollabId",
                table: "CollabArtists",
                column: "CollabId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollabArtists");

            migrationBuilder.DropTable(
                name: "Collabs");
        }
    }
}
