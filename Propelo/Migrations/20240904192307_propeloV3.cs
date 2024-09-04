using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Propelo.Migrations
{
    /// <inheritdoc />
    public partial class propeloV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                schema: "Propelo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Picture",
                schema: "Propelo",
                table: "Promoters");

            migrationBuilder.CreateTable(
                name: "Logos",
                schema: "Propelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoSize = table.Column<long>(type: "bigint", nullable: true),
                    SettingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logos_Settings_SettingId",
                        column: x => x.SettingId,
                        principalSchema: "Propelo",
                        principalTable: "Settings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PromoterPictures",
                schema: "Propelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureSize = table.Column<long>(type: "bigint", nullable: false),
                    PromoterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoterPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoterPictures_Promoters_PromoterId",
                        column: x => x.PromoterId,
                        principalSchema: "Propelo",
                        principalTable: "Promoters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logos_SettingId",
                schema: "Propelo",
                table: "Logos",
                column: "SettingId",
                unique: true,
                filter: "[SettingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PromoterPictures_PromoterId",
                schema: "Propelo",
                table: "PromoterPictures",
                column: "PromoterId",
                unique: true,
                filter: "[PromoterId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logos",
                schema: "Propelo");

            migrationBuilder.DropTable(
                name: "PromoterPictures",
                schema: "Propelo");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                schema: "Propelo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                schema: "Propelo",
                table: "Promoters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
