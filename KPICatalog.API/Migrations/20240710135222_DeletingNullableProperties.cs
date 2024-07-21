using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPICatalog.API.Migrations
{
    /// <inheritdoc />
    public partial class DeletingNullableProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonusSchemeObjectLinks_BonusSchemes_BonusSchemeId",
                table: "BonusSchemeObjectLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_BonusSchemeObjectLinks_LinkedObjectTypes_LinkedObjectTypeId",
                table: "BonusSchemeObjectLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_BonusSchemes_PlanningCycles_PlanningCycleId",
                table: "BonusSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_BonusSchemeLinkMethod_BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_TypicalGoals_TypicalGoalId",
                table: "TypicalGoalInBonusSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoals_PlanningCycles_PlanningCycleId",
                table: "TypicalGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoals_WeightTypes_WeightTypeId",
                table: "TypicalGoals");

            migrationBuilder.AlterColumn<int>(
                name: "WeightTypeId",
                table: "TypicalGoals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanningCycleId",
                table: "TypicalGoals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentGoalId",
                table: "TypicalGoals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypicalGoalId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeKeyResultID",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RatingScaleId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Plan",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentBSTypicalGoalId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Fact",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EvaluationProvider",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EvaluationMethodId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Evaluation",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanningCycleId",
                table: "BonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExternalId",
                table: "BonusSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LinkedObjectTypeId",
                table: "BonusSchemeObjectLinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LinkedObjectId",
                table: "BonusSchemeObjectLinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BonusSchemeId",
                table: "BonusSchemeObjectLinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BonusSchemeObjectLinks_BonusSchemes_BonusSchemeId",
                table: "BonusSchemeObjectLinks",
                column: "BonusSchemeId",
                principalTable: "BonusSchemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BonusSchemeObjectLinks_LinkedObjectTypes_LinkedObjectTypeId",
                table: "BonusSchemeObjectLinks",
                column: "LinkedObjectTypeId",
                principalTable: "LinkedObjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BonusSchemes_PlanningCycles_PlanningCycleId",
                table: "BonusSchemes",
                column: "PlanningCycleId",
                principalTable: "PlanningCycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_BonusSchemeLinkMethod_BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes",
                column: "BonusSchemeLinkMethodId",
                principalTable: "BonusSchemeLinkMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_TypicalGoals_TypicalGoalId",
                table: "TypicalGoalInBonusSchemes",
                column: "TypicalGoalId",
                principalTable: "TypicalGoals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoals_PlanningCycles_PlanningCycleId",
                table: "TypicalGoals",
                column: "PlanningCycleId",
                principalTable: "PlanningCycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoals_WeightTypes_WeightTypeId",
                table: "TypicalGoals",
                column: "WeightTypeId",
                principalTable: "WeightTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonusSchemeObjectLinks_BonusSchemes_BonusSchemeId",
                table: "BonusSchemeObjectLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_BonusSchemeObjectLinks_LinkedObjectTypes_LinkedObjectTypeId",
                table: "BonusSchemeObjectLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_BonusSchemes_PlanningCycles_PlanningCycleId",
                table: "BonusSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_BonusSchemeLinkMethod_BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_TypicalGoals_TypicalGoalId",
                table: "TypicalGoalInBonusSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoals_PlanningCycles_PlanningCycleId",
                table: "TypicalGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoals_WeightTypes_WeightTypeId",
                table: "TypicalGoals");

            migrationBuilder.AlterColumn<int>(
                name: "WeightTypeId",
                table: "TypicalGoals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlanningCycleId",
                table: "TypicalGoals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ParentGoalId",
                table: "TypicalGoals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypicalGoalId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypeKeyResultID",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RatingScaleId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Plan",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ParentBSTypicalGoalId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Fact",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EvaluationProvider",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EvaluationMethodId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Evaluation",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlanningCycleId",
                table: "BonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExternalId",
                table: "BonusSchemes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LinkedObjectTypeId",
                table: "BonusSchemeObjectLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LinkedObjectId",
                table: "BonusSchemeObjectLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BonusSchemeId",
                table: "BonusSchemeObjectLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BonusSchemeObjectLinks_BonusSchemes_BonusSchemeId",
                table: "BonusSchemeObjectLinks",
                column: "BonusSchemeId",
                principalTable: "BonusSchemes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BonusSchemeObjectLinks_LinkedObjectTypes_LinkedObjectTypeId",
                table: "BonusSchemeObjectLinks",
                column: "LinkedObjectTypeId",
                principalTable: "LinkedObjectTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BonusSchemes_PlanningCycles_PlanningCycleId",
                table: "BonusSchemes",
                column: "PlanningCycleId",
                principalTable: "PlanningCycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_BonusSchemeLinkMethod_BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes",
                column: "BonusSchemeLinkMethodId",
                principalTable: "BonusSchemeLinkMethod",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_TypicalGoals_TypicalGoalId",
                table: "TypicalGoalInBonusSchemes",
                column: "TypicalGoalId",
                principalTable: "TypicalGoals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoals_PlanningCycles_PlanningCycleId",
                table: "TypicalGoals",
                column: "PlanningCycleId",
                principalTable: "PlanningCycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoals_WeightTypes_WeightTypeId",
                table: "TypicalGoals",
                column: "WeightTypeId",
                principalTable: "WeightTypes",
                principalColumn: "Id");
        }
    }
}
