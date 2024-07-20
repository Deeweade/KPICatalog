using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPICatalog.API.Migrations
{
    /// <inheritdoc />
    public partial class LinkDateStartEndFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "BonusSchemeObjectLinks",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.MaxValue);
            
            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "BonusSchemeObjectLinks",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BonusSchemeObjectLinks",
                type: "bit",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int?>(
                name: "LinkPercent",
                table: "BonusSchemeObjectLinks",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "BonusSchemeObjectLinks");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "BonusSchemeObjectLinks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BonusSchemeObjectLinks");

            migrationBuilder.DropColumn(
                name: "LinkPercent",
                table: "BonusSchemeObjectLinks");
        }
    }
}
