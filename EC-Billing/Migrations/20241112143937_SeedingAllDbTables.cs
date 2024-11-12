using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECBilling.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAllDbTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    VacationDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "SkillCards",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    SkillsData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCards", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_SkillCards_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => new { x.EmployeeID, x.SkillID });
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    TaskDetail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTasks",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    TaskID = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleInTask = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTasks", x => new { x.EmployeeID, x.TaskID });
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_ProjectTasks_TaskID",
                        column: x => x.TaskID,
                        principalTable: "ProjectTasks",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "ContactInfo", "CustomerName" },
                values: new object[,]
                {
                    { 1, "123 Elm Street", "Good customer", "Acme Corp" },
                    { 2, "456 Oak Avenue", "Bad customer", "Tech Solutions" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Availability", "Department", "FirstName", "LastName", "Title", "VacationDays" },
                values: new object[,]
                {
                    { 1, true, "IT", "John", "Doe", "Project Manager", 15 },
                    { 2, true, "Engineering", "Jane", "Smith", "Developer", 10 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillID", "SkillName" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Blazor" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeID", "SkillID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "CustomerID", "Description", "EmployeeID", "Requirements" },
                values: new object[,]
                {
                    { 1, 1, "A custom CRM for Acme Corp", null, "Build CRM system" },
                    { 2, 2, "Online store for Tech Solutions", null, "E-commerce website" }
                });

            migrationBuilder.InsertData(
                table: "SkillCards",
                columns: new[] { "EmployeeID", "SkillsData" },
                values: new object[,]
                {
                    { 1, "Project Management, Agile" },
                    { 2, "Backend Development, API Integration" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "TaskID", "ProjectID", "TaskDetail" },
                values: new object[,]
                {
                    { 1, 1, "Design database schema" },
                    { 2, 2, "Develop frontend UI" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTasks",
                columns: new[] { "EmployeeID", "TaskID", "AssignedDate", "RoleInTask" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 12, 15, 39, 36, 874, DateTimeKind.Local).AddTicks(4224), "Lead" },
                    { 2, 2, new DateTime(2024, 11, 12, 15, 39, 36, 874, DateTimeKind.Local).AddTicks(4273), "Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillID",
                table: "EmployeeSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_TaskID",
                table: "EmployeeTasks",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerID",
                table: "Projects",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmployeeID",
                table: "Projects",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectID",
                table: "ProjectTasks",
                column: "ProjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "EmployeeTasks");

            migrationBuilder.DropTable(
                name: "SkillCards");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
