using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Propelo.Migrations
{
    /// <inheritdoc />
    public partial class propeloV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                schema: "Propelo",
                table: "PropertyPictures");

            migrationBuilder.DropColumn(
                name: "Picture",
                schema: "Propelo",
                table: "ApartmentPictures");

            migrationBuilder.DropColumn(
                name: "Document",
                schema: "Propelo",
                table: "ApartmentDocuments");

            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                schema: "Propelo",
                table: "PropertyPictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                schema: "Propelo",
                table: "PropertyPictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PictureSize",
                schema: "Propelo",
                table: "PropertyPictures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                schema: "Propelo",
                table: "ApartmentPictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                schema: "Propelo",
                table: "ApartmentPictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PictureSize",
                schema: "Propelo",
                table: "ApartmentPictures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                schema: "Propelo",
                table: "ApartmentDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentPath",
                schema: "Propelo",
                table: "ApartmentDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "DocumentSize",
                schema: "Propelo",
                table: "ApartmentDocuments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureName",
                schema: "Propelo",
                table: "PropertyPictures");

            migrationBuilder.DropColumn(
                name: "PicturePath",
                schema: "Propelo",
                table: "PropertyPictures");

            migrationBuilder.DropColumn(
                name: "PictureSize",
                schema: "Propelo",
                table: "PropertyPictures");

            migrationBuilder.DropColumn(
                name: "PictureName",
                schema: "Propelo",
                table: "ApartmentPictures");

            migrationBuilder.DropColumn(
                name: "PicturePath",
                schema: "Propelo",
                table: "ApartmentPictures");

            migrationBuilder.DropColumn(
                name: "PictureSize",
                schema: "Propelo",
                table: "ApartmentPictures");

            migrationBuilder.DropColumn(
                name: "DocumentName",
                schema: "Propelo",
                table: "ApartmentDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentPath",
                schema: "Propelo",
                table: "ApartmentDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentSize",
                schema: "Propelo",
                table: "ApartmentDocuments");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                schema: "Propelo",
                table: "PropertyPictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                schema: "Propelo",
                table: "ApartmentPictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                schema: "Propelo",
                table: "ApartmentDocuments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
