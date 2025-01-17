using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightNap.DataProviders.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class ChangedKeyContrstraintsForUserRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms");

            migrationBuilder.DropIndex(
                name: "IX_UserRooms_UserId",
                table: "UserRooms");

            migrationBuilder.AlterColumn<string>(
                name: "ConnectionId",
                table: "UserRooms",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms",
                columns: new[] { "UserId", "RoomId", "ConnectionId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRooms_RoomId",
                table: "UserRooms",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms");

            migrationBuilder.DropIndex(
                name: "IX_UserRooms_RoomId",
                table: "UserRooms");

            migrationBuilder.AlterColumn<string>(
                name: "ConnectionId",
                table: "UserRooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms",
                columns: new[] { "RoomId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRooms_UserId",
                table: "UserRooms",
                column: "UserId");
        }
    }
}
