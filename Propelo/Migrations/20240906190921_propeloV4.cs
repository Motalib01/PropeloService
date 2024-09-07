using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Propelo.Migrations
{
    /// <inheritdoc />
    public partial class propeloV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Sold",
                schema: "Propelo",
                table: "Apartments",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sold",
                schema: "Propelo",
                table: "Apartments");
        }
    }
}
