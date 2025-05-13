using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace weatherescu_test_2.Migrations
{
    /// <inheritdoc />
    public partial class InsertingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Temperatures",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Precipitations",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "Humidities",
                columns: new[] { "HumidityID", "CityID", "Value" },
                values: new object[,]
                {
                    { 1, 1, 70 },
                    { 2, 2, 80 },
                    { 3, 3, 75 },
                    { 4, 4, 65 },
                    { 5, 5, 85 }
                });

            migrationBuilder.InsertData(
                table: "Precipitations",
                columns: new[] { "PrecipitationID", "CityID", "Value" },
                values: new object[,]
                {
                    { 1, 1, 10 },
                    { 2, 2, 20 },
                    { 3, 3, 30 },
                    { 4, 4, 40 },
                    { 5, 5, 50 }
                });

            migrationBuilder.InsertData(
                table: "Pressures",
                columns: new[] { "PressureID", "CityID", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1000 },
                    { 2, 2, 1010 },
                    { 3, 3, 1020 },
                    { 4, 4, 1030 },
                    { 5, 5, 1040 }
                });

            migrationBuilder.InsertData(
                table: "Temperatures",
                columns: new[] { "TemperatureID", "CityID", "Value" },
                values: new object[,]
                {
                    { 1, 1, 6 },
                    { 2, 2, 10 },
                    { 3, 3, 8 },
                    { 4, 4, 5 },
                    { 5, 5, 7 }
                });

            migrationBuilder.InsertData(
                table: "WeatherConditions",
                columns: new[] { "WeatherConditionID", "CityID", "Description" },
                values: new object[,]
                {
                    { 1, 1, "Sunny" },
                    { 2, 2, "Rainy" },
                    { 3, 3, "Cloudy" },
                    { 4, 4, "Snowy" },
                    { 5, 5, "Windy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Humidities",
                keyColumn: "HumidityID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Humidities",
                keyColumn: "HumidityID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Humidities",
                keyColumn: "HumidityID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Humidities",
                keyColumn: "HumidityID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Humidities",
                keyColumn: "HumidityID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Precipitations",
                keyColumn: "PrecipitationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Precipitations",
                keyColumn: "PrecipitationID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Precipitations",
                keyColumn: "PrecipitationID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Precipitations",
                keyColumn: "PrecipitationID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Precipitations",
                keyColumn: "PrecipitationID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pressures",
                keyColumn: "PressureID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pressures",
                keyColumn: "PressureID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pressures",
                keyColumn: "PressureID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pressures",
                keyColumn: "PressureID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pressures",
                keyColumn: "PressureID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "TemperatureID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "TemperatureID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "TemperatureID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "TemperatureID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "TemperatureID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WeatherConditions",
                keyColumn: "WeatherConditionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WeatherConditions",
                keyColumn: "WeatherConditionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WeatherConditions",
                keyColumn: "WeatherConditionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WeatherConditions",
                keyColumn: "WeatherConditionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WeatherConditions",
                keyColumn: "WeatherConditionID",
                keyValue: 5);

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "Temperatures",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "Precipitations",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
