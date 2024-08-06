using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPICatalog.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_BonusSchemeLinkMethod_BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonusSchemeLinkMethod",
                table: "BonusSchemeLinkMethod");

            migrationBuilder.RenameTable(
                name: "BonusSchemeLinkMethod",
                newName: "BonusSchemeLinkMethods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonusSchemeLinkMethods",
                table: "BonusSchemeLinkMethods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_BonusSchemeLinkMethods_BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes",
                column: "BonusSchemeLinkMethodId",
                principalTable: "BonusSchemeLinkMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_BonusSchemeLinkMethods_BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonusSchemeLinkMethods",
                table: "BonusSchemeLinkMethods");

            migrationBuilder.RenameTable(
                name: "BonusSchemeLinkMethods",
                newName: "BonusSchemeLinkMethod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonusSchemeLinkMethod",
                table: "BonusSchemeLinkMethod",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalGoalInBonusSchemes_BonusSchemeLinkMethod_BonusSchemeLinkMethodId",
                table: "TypicalGoalInBonusSchemes",
                column: "BonusSchemeLinkMethodId",
                principalTable: "BonusSchemeLinkMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
