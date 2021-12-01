using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalAPI.Migrations
{
    public partial class Registration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergy_Patients_PatientId",
                table: "Allergy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergy",
                table: "Allergy");

            migrationBuilder.DropIndex(
                name: "IX_Allergy_PatientId",
                table: "Allergy");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Allergy");

            migrationBuilder.RenameTable(
                name: "Allergy",
                newName: "Allergies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AllergyPatient",
                columns: table => new
                {
                    AllergiesId = table.Column<string>(type: "text", nullable: false),
                    PatientsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyPatient", x => new { x.AllergiesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_AllergyPatient_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergyPatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergyPatient_PatientsId",
                table: "AllergyPatient",
                column: "PatientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergyPatient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies");

            migrationBuilder.RenameTable(
                name: "Allergies",
                newName: "Allergy");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Allergy",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergy",
                table: "Allergy",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Allergy_PatientId",
                table: "Allergy",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergy_Patients_PatientId",
                table: "Allergy",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
