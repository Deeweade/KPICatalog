using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPICatalog.API.Migrations
{
    /// <inheritdoc />
    public partial class EvaluationMethod_ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TypicalGoalInBonusSchemes_EvaluationMethodId",
                table: "TypicalGoalInBonusSchemes",
                column: "EvaluationMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_EvaluationMethods_EvaluationMethodId",
                table: "TypicalGoalInBonusSchemes",
                column: "EvaluationMethodId",
                principalTable: "EvaluationMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_EvaluationMethods_EvaluationMethodId",
                table: "TypicalGoalInBonusSchemes");

            migrationBuilder.DropIndex(
                name: "IX_TypicalGoalInBonusSchemes_EvaluationMethodId",
                table: "TypicalGoalInBonusSchemes");
        }
    }
}
