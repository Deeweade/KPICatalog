using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPICatalog.API.Migrations
{
    /// <inheritdoc />
    public partial class NewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonusSchemeObjectLinks_LinkedObjectType_LinkedObjectTypeId",
                table: "BonusSchemeObjectLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkedObjectType",
                table: "LinkedObjectType");

            migrationBuilder.RenameTable(
                name: "LinkedObjectType",
                newName: "LinkedObjectTypes");

            migrationBuilder.RenameColumn(
                name: "GoalTypeId",
                table: "TypicalGoals",
                newName: "PlanningCycleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkedObjectTypes",
                table: "LinkedObjectTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BonusSchemeLinkMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusSchemeLinkMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningCycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningCycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypicalGoals_PlanningCycleId",
                table: "TypicalGoals",
                column: "PlanningCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalGoals_WeightTypeId",
                table: "TypicalGoals",
                column: "WeightTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalGoalInBonusSchemes_BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes",
                column: "BonusSchemeLinkMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_BonusSchemes_PlanningCycleId",
                table: "BonusSchemes",
                column: "PlanningCycleId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_TypicalGoals_PlanningCycles_PlanningCycleId",
                table: "TypicalGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoals_WeightTypes_WeightTypeId",
                table: "TypicalGoals");

            migrationBuilder.DropTable(
                name: "BonusSchemeLinkMethod");

            migrationBuilder.DropTable(
                name: "PlanningCycles");

            migrationBuilder.DropTable(
                name: "WeightTypes");

            migrationBuilder.DropIndex(
                name: "IX_TypicalGoals_PlanningCycleId",
                table: "TypicalGoals");

            migrationBuilder.DropIndex(
                name: "IX_TypicalGoals_WeightTypeId",
                table: "TypicalGoals");

            migrationBuilder.DropIndex(
                name: "IX_TypicalGoalInBonusSchemes_BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes");

            migrationBuilder.DropIndex(
                name: "IX_BonusSchemes_PlanningCycleId",
                table: "BonusSchemes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkedObjectTypes",
                table: "LinkedObjectTypes");

            migrationBuilder.RenameTable(
                name: "LinkedObjectTypes",
                newName: "LinkedObjectType");

            migrationBuilder.RenameColumn(
                name: "PlanningCycleId",
                table: "TypicalGoals",
                newName: "GoalTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkedObjectType",
                table: "LinkedObjectType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BonusSchemeObjectLinks_LinkedObjectType_LinkedObjectTypeId",
                table: "BonusSchemeObjectLinks",
                column: "LinkedObjectTypeId",
                principalTable: "LinkedObjectType",
                principalColumn: "Id");
        }
    }
}
