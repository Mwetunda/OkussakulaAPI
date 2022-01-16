using Microsoft.EntityFrameworkCore.Migrations;

namespace Okussakula.Model.Migrations
{
    public partial class AddPreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Instituitions_InstituitionId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_Instituitions_InstituitionId",
                table: "Specialities");

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
                name: "InstituitionId",
                table: "Exams");

            migrationBuilder.AddColumn<string>(
                name: "Preco",
                table: "InstituitionSpecialities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Preco",
                table: "InstituitionExams",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "InstituitionSpecialities");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "InstituitionExams");

            migrationBuilder.AddColumn<long>(
                name: "InstituitionId",
                table: "Specialities",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InstituitionId",
                table: "Exams",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_InstituitionId",
                table: "Specialities",
                column: "InstituitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_InstituitionId",
                table: "Exams",
                column: "InstituitionId");

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
    }
}
