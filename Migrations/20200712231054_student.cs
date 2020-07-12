using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Mgmt_System_MVC.Migrations
{
    public partial class student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course_details",
                columns: table => new
                {
                    course_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_Name = table.Column<string>(nullable: true),
                    start_date = table.Column<DateTime>(nullable: false),
                    end_date = table.Column<DateTime>(nullable: false),
                    course_duration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_details", x => x.course_ID);
                });

            migrationBuilder.CreateTable(
                name: "student_Details",
                columns: table => new
                {
                    student_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_Name = table.Column<string>(nullable: true),
                    student_Email = table.Column<string>(nullable: true),
                    student_Mobile = table.Column<string>(nullable: true),
                    student_Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_Details", x => x.student_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tutor_details",
                columns: table => new
                {
                    tutor_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tutor_Name = table.Column<string>(nullable: true),
                    tutor_Email = table.Column<string>(nullable: true),
                    tutor_Mobile = table.Column<string>(nullable: true),
                    tutor_Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor_details", x => x.tutor_ID);
                });

            migrationBuilder.CreateTable(
                name: "Student_enrollment",
                columns: table => new
                {
                    Student_Enrollment_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_ID = table.Column<int>(nullable: false),
                    student_Detailsstudent_ID = table.Column<int>(nullable: true),
                    course_ID = table.Column<int>(nullable: false),
                    Course_Detailscourse_ID = table.Column<int>(nullable: true),
                    tutor_ID = table.Column<int>(nullable: false),
                    tutor_Detailstutor_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_enrollment", x => x.Student_Enrollment_ID);
                    table.ForeignKey(
                        name: "FK_Student_enrollment_Course_details_Course_Detailscourse_ID",
                        column: x => x.Course_Detailscourse_ID,
                        principalTable: "Course_details",
                        principalColumn: "course_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_enrollment_student_Details_student_Detailsstudent_ID",
                        column: x => x.student_Detailsstudent_ID,
                        principalTable: "student_Details",
                        principalColumn: "student_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_enrollment_Tutor_details_tutor_Detailstutor_ID",
                        column: x => x.tutor_Detailstutor_ID,
                        principalTable: "Tutor_details",
                        principalColumn: "tutor_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_enrollment_Course_Detailscourse_ID",
                table: "Student_enrollment",
                column: "Course_Detailscourse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_enrollment_student_Detailsstudent_ID",
                table: "Student_enrollment",
                column: "student_Detailsstudent_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_enrollment_tutor_Detailstutor_ID",
                table: "Student_enrollment",
                column: "tutor_Detailstutor_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_enrollment");

            migrationBuilder.DropTable(
                name: "Course_details");

            migrationBuilder.DropTable(
                name: "student_Details");

            migrationBuilder.DropTable(
                name: "Tutor_details");
        }
    }
}
