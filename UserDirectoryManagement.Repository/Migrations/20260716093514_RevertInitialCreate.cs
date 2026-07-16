using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserDirectoryManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RevertInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltLink",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ETag",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SelfLink",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "User",
                newName: "State");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "User",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pincode",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "User");

            migrationBuilder.DropColumn(
                name: "City",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Pincode",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "User",
                newName: "Timestamp");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "User",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "AltLink",
                table: "User",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ETag",
                table: "User",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResourceId",
                table: "User",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelfLink",
                table: "User",
                type: "TEXT",
                nullable: true);
        }
    }
}
