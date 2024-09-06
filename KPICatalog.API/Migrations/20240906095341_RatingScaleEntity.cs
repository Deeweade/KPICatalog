using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPICatalog.API.Migrations
{
    /// <inheritdoc />
    public partial class RatingScaleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RatingScales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingScales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatingScaleValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingScaleId = table.Column<int>(type: "int", nullable: false),
                    MinimumValue = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    MaximumValue = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    RatingPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingScaleValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingScaleValues_RatingScales_RatingScaleId",
                        column: x => x.RatingScaleId,
                        principalTable: "RatingScales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypicalGoalInBonusSchemes_RatingScaleId",
                table: "TypicalGoalInBonusSchemes",
                column: "RatingScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingScaleValues_RatingScaleId",
                table: "RatingScaleValues",
                column: "RatingScaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_RatingScales_RatingScaleId",
                table: "TypicalGoalInBonusSchemes",
                column: "RatingScaleId",
                principalTable: "RatingScales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_RatingScales_RatingScaleId",
                table: "TypicalGoalInBonusSchemes");

            migrationBuilder.DropTable(
                name: "RatingScaleValues");

            migrationBuilder.DropTable(
                name: "RatingScales");

            migrationBuilder.DropIndex(
                name: "IX_TypicalGoalInBonusSchemes_RatingScaleId",
                table: "TypicalGoalInBonusSchemes");
        }
    }
}
