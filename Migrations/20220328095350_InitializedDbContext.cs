using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_Responsitory.Migrations
{
    public partial class InitializedDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLASS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classroom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLASS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudent",
                columns: table => new
                {
                    ClassesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudent", x => new { x.ClassesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ClassStudent_CLASS_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "CLASS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudent_STUDENT_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "STUDENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudent_StudentsId",
                table: "ClassStudent",
                column: "StudentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudent");

            migrationBuilder.DropTable(
                name: "CLASS");

            migrationBuilder.DropTable(
                name: "STUDENT");
        }
    }
}
