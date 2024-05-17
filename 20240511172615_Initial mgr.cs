using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auctions.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initialmgr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    IdentityUserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listing_AspNetUsers_IdentityUserID",
                        column: x => x.IdentityUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IdentityUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bid_AspNetUsers_IdentityUserID",
                        column: x => x.IdentityUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bid_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_IdentityUserID",
                        column: x => x.IdentityUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bid_IdentityUserID",
                table: "Bid",
                column: "IdentityUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_ListingId",
                table: "Bid",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IdentityUserID",
                table: "Comment",
                column: "IdentityUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ListingId",
                table: "Comment",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_IdentityUserID",
                table: "Listing",
                column: "IdentityUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Listing");
        }
    }
}
