using Car_Rental.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Rental.Migrations
{
    /// <inheritdoc />
    public partial class SeedTablesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                    // Seed Locations
        migrationBuilder.InsertData(
            table: "Locations",
            columns: new[] { "LocationId", "City", "Country" },
            values: new object[,]
            {
                { 1, "New York", "USA" },
                { 2, "Berlin", "Germany" },
                { 3, "Tokyo", "Japan" },
                { 4, "Sydney", "Australia" },
                { 5, "London", "United Kingdom" }
            });

        // Seed Cars
        migrationBuilder.InsertData(
            table: "Cars",
            columns: new[] { "CarId", "Make", "Model", "Year", "LicensePlate", "LocationId" },
            values: new object[,]
            {
                { 1, "Toyota", "Camry", 2022, "NY1234", 1 },
                { 2, "Volkswagen", "Golf", 2021, "BER1234", 2 },
                { 3, "Honda", "Civic", 2020, "TOK1234", 3 },
                { 4, "Ford", "Focus", 2019, "SYD1234", 4 },
                { 5, "Chevrolet", "Impala", 2018, "LON1234", 5 }
            });

        // Seed Users
        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "UserId", "FirstName", "LastName", "Email", "Password", "PhoneNumber", "DateOfBirth", "AddressOne", "City", "Country", "LicenseNumber" },
            values: new object[,]
            {
                { 1, "John", "Doe", "johndoe@example.com", "password123", "555-1234", new DateTime(1985, 8, 15), "123 Maple Street", "New York", "USA", "D1234567" },
                { 2, "Alice", "Johnson", "alicejohnson@example.com", "password123", "555-5678", new DateTime(1990, 12, 11), "234 Oak Avenue", "Berlin", "Germany", "G2345678" },
                { 3, "Bob", "Smith", "bobsmith@example.com", "password123", "555-9012", new DateTime(1988, 3, 22), "345 Pine Road", "Tokyo", "Japan", "J3456789" },
                { 4, "Mary", "Lee", "marylee@example.com", "password123", "555-3456", new DateTime(1992, 7, 19), "456 Birch Lane", "Sydney", "Australia", "A4567890" },
                { 5, "David", "Wilson", "davidwilson@example.com", "password123", "555-7890", new DateTime(1987, 11, 25), "567 Cedar Path", "London", "United Kingdom", "U5678901" }
            });

        // Seed Reservations
        migrationBuilder.InsertData(
            table: "Reservations",
            columns: new[] { "ReservationId", "CarId", "UserId", "StartDate", "EndDate", "ReservationStatus" },
            values: new object[,]
            {
                { 1, 1, 1, new DateTime(2023, 10, 1), new DateTime(2023, 10, 3), 0 },  // Reserved
                { 2, 2, 2, new DateTime(2023, 10, 4), new DateTime(2023, 10, 6), 0 },  // Reserved
                { 3, 3, 3, new DateTime(2023, 10, 7), new DateTime(2023, 10, 9), 1 },  // Completed
                { 4, 4, 4, new DateTime(2023, 10, 10), new DateTime(2023, 10, 12), 0 }, // Reserved
                { 5, 5, 5, new DateTime(2023, 10, 13), new DateTime(2023, 10, 15), 1 }  // Completed
            });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Reservations", keyColumn: "ReservationId", keyValues: new object[] { 1, 2, 3, 4, 5 });
            migrationBuilder.DeleteData(table: "Users", keyColumn: "UserId", keyValues: new object[] { 1, 2, 3, 4, 5 });
            migrationBuilder.DeleteData(table: "Cars", keyColumn: "CarId", keyValues: new object[] { 1, 2, 3, 4, 5 });
            migrationBuilder.DeleteData(table: "Locations", keyColumn: "LocationId", keyValues: new object[] { 1, 2, 3, 4, 5 });
        }

    }
}
