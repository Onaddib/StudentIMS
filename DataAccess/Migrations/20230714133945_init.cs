using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Depart = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNumber = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Depart" },
                values: new object[] { 1, "Business Administration" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Depart" },
                values: new object[] { 2, "Computer Science" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Depart" },
                values: new object[] { 3, "Management Information Systems" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "DepartmentId", "Name", "StudentNumber", "Surname" },
                values: new object[,]
                {
                    { 1, 20, 1, "John", 123456, "Dae" },
                    { 2, 21, 1, "Sam", 258369, "Dalton" },
                    { 3, 19, 1, "Paul", 259354, "Wise" },
                    { 4, 22, 1, "Stacy", 685478, "Willer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
