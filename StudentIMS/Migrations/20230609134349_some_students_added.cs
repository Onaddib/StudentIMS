using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class some_students_addes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {  
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Name", "StudentNumber", "Surname" },
                values: new object[,]
                {
                    { 1, 20, "John", 123456, "Dae" },
                    { 2, 21, "Sam", 258369, "Dalton" },
                    { 3, 19, "Paul", 259354, "Wise" },
                    { 4, 22, "Stacy", 685478, "Willer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
