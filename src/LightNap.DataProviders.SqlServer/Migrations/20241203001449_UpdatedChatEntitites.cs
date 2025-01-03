using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightNap.DataProviders.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedChatEntitites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoom_AspNetUsers_UserId",
                table: "UserRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoom_Room_RoomId",
                table: "UserRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoom",
                table: "UserRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "UserRoom",
                newName: "UserRooms");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoom_UserId",
                table: "UserRooms",
                newName: "IX_UserRooms_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "ConnectionId",
                table: "UserRooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SentByUserId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms",
                columns: new[] { "RoomId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_AspNetUsers_UserId",
                table: "UserRooms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_AspNetUsers_UserId",
                table: "UserRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "UserRooms",
                newName: "UserRoom");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_UserRooms_UserId",
                table: "UserRoom",
                newName: "IX_UserRoom_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "ConnectionId",
                table: "UserRoom",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SentByUserId",
                table: "Message",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoom",
                table: "UserRoom",
                columns: new[] { "RoomId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoom_AspNetUsers_UserId",
                table: "UserRoom",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoom_Room_RoomId",
                table: "UserRoom",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
