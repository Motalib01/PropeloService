﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Propelo.Migrations
{
    /// <inheritdoc />
    public partial class propeloV7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "Propelo",
                table: "PromoterPictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                schema: "Propelo",
                table: "PromoterPictures");
        }
    }
}
