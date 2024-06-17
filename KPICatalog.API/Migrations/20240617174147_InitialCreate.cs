using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPICatalog.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BonusSchemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefaulBonusScheme = table.Column<bool>(type: "bit", nullable: false),
                    ExternalId = table.Column<int>(type: "int", nullable: true),
                    PlanningCycleId = table.Column<int>(type: "int", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusSchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkedObjectType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedObjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypicalGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoalTypeId = table.Column<int>(type: "int", nullable: true),
                    WeightTypeId = table.Column<int>(type: "int", nullable: true),
                    ParentGoalId = table.Column<int>(type: "int", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypicalGoals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccessControls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccessGranted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessControls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BonusSchemeObjectLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BonusSchemeId = table.Column<int>(type: "int", nullable: true),
                    LinkedObjectId = table.Column<int>(type: "int", nullable: true),
                    LinkedObjectTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusSchemeObjectLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonusSchemeObjectLinks_BonusSchemes_BonusSchemeId",
                        column: x => x.BonusSchemeId,
                        principalTable: "BonusSchemes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BonusSchemeObjectLinks_LinkedObjectType_LinkedObjectTypeId",
                        column: x => x.LinkedObjectTypeId,
                        principalTable: "LinkedObjectType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TypicalGoalInBonusSchemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypicalGoalId = table.Column<int>(type: "int", nullable: true),
                    ParentBSTypicalGoalId = table.Column<int>(type: "int", nullable: true),
                    PeriodId = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Plan = table.Column<int>(type: "int", nullable: true),
                    TypeKeyResultID = table.Column<int>(type: "int", nullable: true),
                    EvaluationProvider = table.Column<int>(type: "int", nullable: true),
                    BonusSchemeLinkMethodId = table.Column<int>(type: "int", nullable: true),
                    EvaluationMethodId = table.Column<int>(type: "int", nullable: true),
                    RatingScaleId = table.Column<int>(type: "int", nullable: true),
                    Fact = table.Column<int>(type: "int", nullable: true),
                    Evaluation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypicalGoalInBonusSchemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypicalGoalInBonusSchemes_TypicalGoals_TypicalGoalId",
                        column: x => x.TypicalGoalId,
                        principalTable: "TypicalGoals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BonusSchemeObjectLinks_BonusSchemeId",
                table: "BonusSchemeObjectLinks",
                column: "BonusSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_BonusSchemeObjectLinks_LinkedObjectTypeId",
                table: "BonusSchemeObjectLinks",
                column: "LinkedObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalGoalInBonusSchemes_TypicalGoalId",
                table: "TypicalGoalInBonusSchemes",
                column: "TypicalGoalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonusSchemeObjectLinks");

            migrationBuilder.DropTable(
                name: "TypicalGoalInBonusSchemes");

            migrationBuilder.DropTable(
                name: "UserAccessControls");

            migrationBuilder.DropTable(
                name: "BonusSchemes");

            migrationBuilder.DropTable(
                name: "LinkedObjectType");

            migrationBuilder.DropTable(
                name: "TypicalGoals");
        }
    }
}
