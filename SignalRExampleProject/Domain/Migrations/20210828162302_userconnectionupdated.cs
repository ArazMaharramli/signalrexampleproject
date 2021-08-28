using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRExampleProject.domain.Migrations
{
    public partial class userconnectionupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connection_AspNetUsers_UserId",
                table: "Connection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Connection",
                table: "Connection");

            migrationBuilder.RenameTable(
                name: "Connection",
                newName: "Connections");

            migrationBuilder.RenameIndex(
                name: "IX_Connection_UserId",
                table: "Connections",
                newName: "IX_Connections_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Connections",
                table: "Connections",
                column: "ConnectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_AspNetUsers_UserId",
                table: "Connections",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_AspNetUsers_UserId",
                table: "Connections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Connections",
                table: "Connections");

            migrationBuilder.RenameTable(
                name: "Connections",
                newName: "Connection");

            migrationBuilder.RenameIndex(
                name: "IX_Connections_UserId",
                table: "Connection",
                newName: "IX_Connection_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Connection",
                table: "Connection",
                column: "ConnectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Connection_AspNetUsers_UserId",
                table: "Connection",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
