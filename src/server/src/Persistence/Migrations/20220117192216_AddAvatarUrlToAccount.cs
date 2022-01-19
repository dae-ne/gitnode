using Microsoft.EntityFrameworkCore.Migrations;

namespace GitNode.Persistence.Migrations
{
    public partial class AddAvatarUrlToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "refresh_token",
                table: "accounts",
                newName: "avatar_url");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "repos",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "avatar_url",
                table: "accounts",
                newName: "refresh_token");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "repos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);
        }
    }
}
