using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AfroBeachApp.Migrations
{
    /// <inheritdoc />
    public partial class ModifySystemInfo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaType_SystemInfos_SystemInfoId",
                table: "SocialMediaType");

            migrationBuilder.DropIndex(
                name: "IX_SocialMediaType_SystemInfoId",
                table: "SocialMediaType");

            migrationBuilder.DropColumn(
                name: "SystemInfoId",
                table: "SocialMediaType");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "SystemInfos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "SystemInfos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TikTokUrl",
                table: "SystemInfos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "SystemInfos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SocialMediaType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5132), new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5151) });

            migrationBuilder.UpdateData(
                table: "SocialMediaType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5154), new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5156) });

            migrationBuilder.UpdateData(
                table: "SocialMediaType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5158), new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5159) });

            migrationBuilder.UpdateData(
                table: "SocialMediaType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5162), new DateTime(2023, 12, 18, 18, 12, 30, 980, DateTimeKind.Local).AddTicks(5164) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "SystemInfos");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "SystemInfos");

            migrationBuilder.DropColumn(
                name: "TikTokUrl",
                table: "SystemInfos");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "SystemInfos");

            migrationBuilder.AddColumn<int>(
                name: "SystemInfoId",
                table: "SocialMediaType",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SocialMediaType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn", "SystemInfoId" },
                values: new object[] { new DateTime(2023, 12, 17, 2, 59, 3, 987, DateTimeKind.Local).AddTicks(8166), new DateTime(2023, 12, 17, 2, 59, 3, 987, DateTimeKind.Local).AddTicks(8186), null });

            migrationBuilder.UpdateData(
                table: "SocialMediaType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn", "SystemInfoId" },
                values: new object[] { new DateTime(2023, 12, 17, 2, 59, 3, 987, DateTimeKind.Local).AddTicks(8187), new DateTime(2023, 12, 17, 2, 59, 3, 987, DateTimeKind.Local).AddTicks(8189), null });

            migrationBuilder.UpdateData(
                table: "SocialMediaType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn", "SystemInfoId" },
                values: new object[] { new DateTime(2023, 12, 17, 2, 59, 3, 987, DateTimeKind.Local).AddTicks(8190), new DateTime(2023, 12, 17, 2, 59, 3, 987, DateTimeKind.Local).AddTicks(8191), null });

            migrationBuilder.UpdateData(
                table: "SocialMediaType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn", "SystemInfoId" },
                values: new object[] { new DateTime(2023, 12, 17, 2, 59, 3, 987, DateTimeKind.Local).AddTicks(8192), new DateTime(2023, 12, 17, 2, 59, 3, 987, DateTimeKind.Local).AddTicks(8193), null });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaType_SystemInfoId",
                table: "SocialMediaType",
                column: "SystemInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaType_SystemInfos_SystemInfoId",
                table: "SocialMediaType",
                column: "SystemInfoId",
                principalTable: "SystemInfos",
                principalColumn: "Id");
        }
    }
}
