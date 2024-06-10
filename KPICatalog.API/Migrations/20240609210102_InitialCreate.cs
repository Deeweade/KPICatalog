using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    CostCenter = table.Column<string>(type: "text", nullable: true),
                    IsDefaulBonusScheme = table.Column<bool>(type: "boolean", nullable: false),
                    ExternalId = table.Column<int>(type: "integer", nullable: true),
                    PlanningCycleId = table.Column<int>(type: "integer", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusSchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkedObjectType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedObjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccessControls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: true),
                    IsAccessGranted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessControls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BonusSchemeObjectLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BonusSchemeId = table.Column<int>(type: "integer", nullable: true),
                    LinkedObjectId = table.Column<int>(type: "integer", nullable: true),
                    LinkedObjectTypeId = table.Column<int>(type: "integer", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_BonusSchemeObjectLinks_BonusSchemeId",
                table: "BonusSchemeObjectLinks",
                column: "BonusSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_BonusSchemeObjectLinks_LinkedObjectTypeId",
                table: "BonusSchemeObjectLinks",
                column: "LinkedObjectTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonusSchemeObjectLinks");

            migrationBuilder.DropTable(
                name: "UserAccessControls");

            migrationBuilder.DropTable(
                name: "BonusSchemes");

            migrationBuilder.DropTable(
                name: "LinkedObjectType");
        }
    }
}
