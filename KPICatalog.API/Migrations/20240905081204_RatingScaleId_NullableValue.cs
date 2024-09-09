using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPICatalog.API.Migrations
{
    /// <inheritdoc />
    public partial class RatingScaleId_NullableValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_RatingScales_RatingScaleId",
                table: "TypicalGoalInBonusSchemes");

            migrationBuilder.AlterColumn<int>(
                name: "RatingScaleId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_RatingScales_RatingScaleId",
                table: "TypicalGoalInBonusSchemes",
                column: "RatingScaleId",
                principalTable: "RatingScales",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_RatingScales_RatingScaleId",
                table: "TypicalGoalInBonusSchemes");

            migrationBuilder.AlterColumn<int>(
                name: "RatingScaleId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_RatingScales_RatingScaleId",
                table: "TypicalGoalInBonusSchemes",
                column: "RatingScaleId",
                principalTable: "RatingScales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
