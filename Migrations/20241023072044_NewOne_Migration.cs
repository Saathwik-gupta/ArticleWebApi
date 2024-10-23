using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleWebApi.Migrations
{
    /// <inheritdoc />
    public partial class NewOne_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsActive" },
                values: new object[] { new DateTime(2024, 10, 23, 7, 20, 42, 324, DateTimeKind.Utc).AddTicks(5987), true });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "IsActive" },
                values: new object[] { new DateTime(2024, 10, 23, 7, 20, 42, 324, DateTimeKind.Utc).AddTicks(5993), true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Articles");
        }
    }
}
