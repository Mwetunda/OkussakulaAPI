using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Okussakula.Model.Migrations
{
    public partial class ActualMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelect",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "InstituitionId",
                table: "Specialities",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Specialities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Instituitions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Instituitions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Instituitions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "InstituitionId",
                table: "Exams",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Exams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CronogramConsults",
                columns: table => new
                {
                    CronogramConsultId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituitionSpecialityId = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CronogramConsults", x => x.CronogramConsultId);
                    table.ForeignKey(
                        name: "FK_CronogramConsults_InstituitionSpecialities_InstituitionSpecialityId",
                        column: x => x.InstituitionSpecialityId,
                        principalTable: "InstituitionSpecialities",
                        principalColumn: "InstituitionSpecialityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CronogramExams",
                columns: table => new
                {
                    CronogramExamId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituitionExamId = table.Column<long>(type: "bigint", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CronogramExams", x => x.CronogramExamId);
                    table.ForeignKey(
                        name: "FK_CronogramExams_InstituitionExams_InstituitionExamId",
                        column: x => x.InstituitionExamId,
                        principalTable: "InstituitionExams",
                        principalColumn: "InstituitionExamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultHorarios",
                columns: table => new
                {
                    ConsultHorarioId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CronogramConsultId = table.Column<long>(type: "bigint", nullable: false),
                    Hora = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultHorarios", x => x.ConsultHorarioId);
                    table.ForeignKey(
                        name: "FK_ConsultHorarios_CronogramConsults_CronogramConsultId",
                        column: x => x.CronogramConsultId,
                        principalTable: "CronogramConsults",
                        principalColumn: "CronogramConsultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamHorarios",
                columns: table => new
                {
                    ExamHorarioId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CronogramExamId = table.Column<long>(type: "bigint", nullable: false),
                    Hora = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamHorarios", x => x.ExamHorarioId);
                    table.ForeignKey(
                        name: "FK_ExamHorarios_CronogramExams_CronogramExamId",
                        column: x => x.CronogramExamId,
                        principalTable: "CronogramExams",
                        principalColumn: "CronogramExamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consults",
                columns: table => new
                {
                    ConsultId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ConsultHorarioId = table.Column<long>(type: "bigint", nullable: false),
                    DataInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consults", x => x.ConsultId);
                    table.ForeignKey(
                        name: "FK_Consults_ConsultHorarios_ConsultHorarioId",
                        column: x => x.ConsultHorarioId,
                        principalTable: "ConsultHorarios",
                        principalColumn: "ConsultHorarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consults_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamMedics",
                columns: table => new
                {
                    ExamMedicId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ExamHorarioId = table.Column<long>(type: "bigint", nullable: false),
                    DataInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamMedics", x => x.ExamMedicId);
                    table.ForeignKey(
                        name: "FK_ExamMedics_ExamHorarios_ExamHorarioId",
                        column: x => x.ExamHorarioId,
                        principalTable: "ExamHorarios",
                        principalColumn: "ExamHorarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamMedics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_InstituitionId",
                table: "Specialities",
                column: "InstituitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_InstituitionId",
                table: "Exams",
                column: "InstituitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultHorarios_CronogramConsultId",
                table: "ConsultHorarios",
                column: "CronogramConsultId");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_ConsultHorarioId",
                table: "Consults",
                column: "ConsultHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_UserId",
                table: "Consults",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CronogramConsults_InstituitionSpecialityId",
                table: "CronogramConsults",
                column: "InstituitionSpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_CronogramExams_InstituitionExamId",
                table: "CronogramExams",
                column: "InstituitionExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamHorarios_CronogramExamId",
                table: "ExamHorarios",
                column: "CronogramExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamMedics_ExamHorarioId",
                table: "ExamMedics",
                column: "ExamHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamMedics_UserId",
                table: "ExamMedics",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Instituitions_InstituitionId",
                table: "Exams",
                column: "InstituitionId",
                principalTable: "Instituitions",
                principalColumn: "InstituitionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_Instituitions_InstituitionId",
                table: "Specialities",
                column: "InstituitionId",
                principalTable: "Instituitions",
                principalColumn: "InstituitionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Instituitions_InstituitionId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_Instituitions_InstituitionId",
                table: "Specialities");

            migrationBuilder.DropTable(
                name: "Consults");

            migrationBuilder.DropTable(
                name: "ExamMedics");

            migrationBuilder.DropTable(
                name: "ConsultHorarios");

            migrationBuilder.DropTable(
                name: "ExamHorarios");

            migrationBuilder.DropTable(
                name: "CronogramConsults");

            migrationBuilder.DropTable(
                name: "CronogramExams");

            migrationBuilder.DropIndex(
                name: "IX_Specialities_InstituitionId",
                table: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Exams_InstituitionId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "InstituitionId",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Instituitions");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Instituitions");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Instituitions");

            migrationBuilder.DropColumn(
                name: "InstituitionId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Exams");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelect",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
