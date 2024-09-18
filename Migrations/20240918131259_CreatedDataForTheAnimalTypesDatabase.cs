using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Farm.Migrations
{
    /// <inheritdoc />
    public partial class CreatedDataForTheAnimalTypesDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "animal_types",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 6, "vertebrado de sangre fria con escamas", "reptil" },
                    { 7, "animales que beben leche", "mamifero" },
                    { 8, "animales que consumen exclusivamente carne", "carnivoros" },
                    { 9, "animales que consumen tanto carne como plantas", "ominvoros" },
                    { 10, "animales que consumen exclusivamente plantas", "herbivoros" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "animal_types",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "animal_types",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "animal_types",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "animal_types",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "animal_types",
                keyColumn: "id",
                keyValue: 10);
        }
    }
}
