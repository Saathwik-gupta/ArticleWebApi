using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleWebApi.Migrations
{
    /// <inheritdoc />
    public partial class removedDelete_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 23, 11, 8, 54, 339, DateTimeKind.Utc).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 23, 11, 8, 54, 339, DateTimeKind.Utc).AddTicks(6011));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 10, 23, 7, 50, 39, 321, DateTimeKind.Utc).AddTicks(8957), false });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "IsDeleted" },
                values: new object[] { new DateTime(2024, 10, 23, 7, 50, 39, 321, DateTimeKind.Utc).AddTicks(8964), false });
        }
    }
}
