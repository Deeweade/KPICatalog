using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KPICatalog.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BonusSchemeLinkMethod",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "На сотрудника" },
                    { 2, "На бонусную схему" },
                    { 3, "На всех" }
                });

            migrationBuilder.InsertData(
                table: "EvaluationMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Прямой" },
                    { 2, "Обратно-пропорциональный" },
                    { 3, "Шкала SLA" }
                });

            migrationBuilder.InsertData(
                table: "LinkedObjectTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BS-Employee" },
                    { 2, "BS-Goal" },
                    { 3, "BS-Request" },
                    { 4, "BS-Group" }
                });

            migrationBuilder.InsertData(
                table: "PlanningCycles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Годовая цель" },
                    { 2, "ЛОКР" },
                    { 3, "Критерий достижения" },
                    { 4, "Квартальная цель" },
                    { 5, "Месячная цель" }
                });

            migrationBuilder.InsertData(
                table: "WeightTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Процент" },
                    { 2, "Тариф" },
                    { 3, "Комиссия" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BonusSchemeLinkMethod",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BonusSchemeLinkMethod",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BonusSchemeLinkMethod",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EvaluationMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EvaluationMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EvaluationMethods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LinkedObjectTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LinkedObjectTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LinkedObjectTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LinkedObjectTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlanningCycles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlanningCycles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlanningCycles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlanningCycles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlanningCycles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WeightTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WeightTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WeightTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
