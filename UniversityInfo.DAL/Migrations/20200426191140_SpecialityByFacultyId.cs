using Microsoft.EntityFrameworkCore.Migrations;

namespace MentorAbiturienta.DAL.Migrations
{
    public partial class SpecialityByFacultyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Specialties_SpecialityId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SpecialityId",
                table: "Students");

            //migrationBuilder.DropIndex(
            //    name: "IX_SpecialityByFaculty_SpecialityId",
            //    table: "SpecialityByFaculty");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "SpecialityByFacultyId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SpecialityByFacultyId",
                table: "Students",
                column: "SpecialityByFacultyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SpecialityByFaculty_SpecialityId",
            //    table: "SpecialityByFaculty",
            //    column: "SpecialityId",
            //    unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SpecialityByFaculty_SpecialityByFacultyId",
                table: "Students",
                column: "SpecialityByFacultyId",
                principalTable: "SpecialityByFaculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_SpecialityByFaculty_SpecialityByFacultyId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SpecialityByFacultyId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_SpecialityByFaculty_SpecialityId",
                table: "SpecialityByFaculty");

            migrationBuilder.DropColumn(
                name: "SpecialityByFacultyId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SpecialityId",
                table: "Students",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityByFaculty_SpecialityId",
                table: "SpecialityByFaculty",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Specialties_SpecialityId",
                table: "Students",
                column: "SpecialityId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
