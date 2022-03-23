using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_Responsitory.Migrations
{
    public partial class kieu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudent_STUDENT_StudentsesId",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "STUDENT");

            migrationBuilder.RenameColumn(
                name: "StudentsesId",
                table: "ClassStudent",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassStudent_StudentsesId",
                table: "ClassStudent",
                newName: "IX_ClassStudent_StudentsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "STUDENT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birth",
                table: "STUDENT",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CLASS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Classroom",
                table: "CLASS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudent_STUDENT_StudentsId",
                table: "ClassStudent",
                column: "StudentsId",
                principalTable: "STUDENT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudent_STUDENT_StudentsId",
                table: "ClassStudent");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "ClassStudent",
                newName: "StudentsesId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassStudent_StudentsId",
                table: "ClassStudent",
                newName: "IX_ClassStudent_StudentsesId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "STUDENT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Birth",
                table: "STUDENT",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "STUDENT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CLASS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Classroom",
                table: "CLASS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudent_STUDENT_StudentsesId",
                table: "ClassStudent",
                column: "StudentsesId",
                principalTable: "STUDENT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
