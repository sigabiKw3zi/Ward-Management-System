using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualHealthProject.Migrations
{
    /// <inheritdoc />
    public partial class sssvvv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisit_AspNetUsers_UserId",
                table: "DoctorVisit");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisit_Patients_PatientID",
                table: "DoctorVisit");

            migrationBuilder.DropForeignKey(
                name: "FK_Vitals_AspNetUsers_UserId",
                table: "Vitals");

            migrationBuilder.DropIndex(
                name: "IX_Vitals_UserId",
                table: "Vitals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorVisit",
                table: "DoctorVisit");

            migrationBuilder.DropIndex(
                name: "IX_DoctorVisit_PatientID",
                table: "DoctorVisit");

            migrationBuilder.DropColumn(
                name: "CurrentMed",
                table: "Vitals");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Vitals");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Vitals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vitals");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "DoctorVisit");

            migrationBuilder.DropColumn(
                name: "VisitDateTime",
                table: "DoctorVisit");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Vitals",
                newName: "VitalsId");

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DoctorVisit",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "DoctorVisit",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "NurseDispense",
                columns: table => new
                {
                    DispenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledMedication = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatePrescribed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseDispense", x => x.DispenceId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15a39159-9060-4425-8c3e-ba218c4ca37d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2270a20d-0e0a-4c01-8702-22c38e309a4d", "AQAAAAIAAYagAAAAEETKsb2uElcBEOwoJr6g2Roll/iMuU6U25YXvAEjhvu5l6z0KEUUisb36tguqC+fYw==", "32a712ef-f5db-4579-968f-229737af1fe2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a9554cf-747d-4afb-81c0-4114eb8f8733",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a09fd9db-89ec-4c90-a1cb-23b388fcb883", "AQAAAAIAAYagAAAAEJMK906yU/6LmOad7vgO8QjLkyAm3ZGEx1GB/aVxEbsPt5m9U9p0e7AYAtNB6ICb2Q==", "528700d3-2f54-4485-87f2-5865b56dc39b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f270bed-70c3-46c2-bd83-c47b73eb7e2d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3e54e7e-b16b-4779-b057-27bffdb4ce9d", "AQAAAAIAAYagAAAAEG/b32z1//9GJGSESsLZgRxxwghzzWshjbv5EP0XsIbBC+pa24UTz5Ud1UaFxZV4/Q==", "be5e3386-dc0d-4965-9c3c-674a295f98dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "854428da-d335-45ef-a793-dced73bbff77",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7beb1e3c-4c47-46ac-872d-5d8d99120422", "AQAAAAIAAYagAAAAEMXvaruuXfRqTfPYZQDkKVjpXFrSVfLFy4yJRIWaXV7qbyH0faTfcAus1vOUTDEzbA==", "eb6137fa-3247-4ac4-96cd-c433984a01f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9668a0c8-1c05-4240-b413-18b4c4bf1873",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be8f49b2-b8ca-4ace-a156-6fd1febe72be", "AQAAAAIAAYagAAAAEPwQuWtCa+mqAZLjTjxDJkHEHajDZi+RTleyT4wMdcBZUTfFazInwKbcd7QB+OzohA==", "f4529b04-3e17-4160-b3df-f7fe4f4a52ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2f48359-0469-43b0-8654-f61b9d1ab286",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a49fb4e-8f62-4579-8ea4-5a0243a61e58", "AQAAAAIAAYagAAAAEMUYYi7wWlnDoP6yBIQ17jZsuPyRRSPib7etWbU07ozL5ruxNJ3NNDCizG0AxPwNhw==", "d2457ea8-c4b3-4b04-8a38-a706fa125f7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4e8abc4-dbbf-406d-8031-20509b79c1a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af1d7da1-78d4-48c0-9882-adf196d827a9", "AQAAAAIAAYagAAAAECMoAvyGd9VLy9UuCMfn30kqnL2hdyFPgxIBeX2/XzMcSfvw3kVuF7VuovEi4HhvDg==", "e8b7121e-940e-45b5-b976-52aa3b9004e6" });

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorVisit_AspNetUsers_UserId",
                table: "DoctorVisit",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisit_AspNetUsers_UserId",
                table: "DoctorVisit");

            migrationBuilder.DropTable(
                name: "NurseDispense");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "Prescription");

            migrationBuilder.RenameColumn(
                name: "VitalsId",
                table: "Vitals",
                newName: "PatientId");

            migrationBuilder.AddColumn<string>(
                name: "CurrentMed",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Vitals",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Vitals",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Vitals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "DoctorVisit",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DoctorVisit",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "DoctorVisit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "VisitDateTime",
                table: "DoctorVisit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorVisit",
                table: "DoctorVisit",
                column: "VisitId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15a39159-9060-4425-8c3e-ba218c4ca37d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43a82b5d-1f72-4236-8a77-76599bf80f00", "AQAAAAIAAYagAAAAEC3mS05xaBG9sAt3w4JzTMfsTn58wDj6YGjGScwWhCimpN8QntH5Pgex8vhI4m/VkA==", "50b66259-f58f-4ec7-8a42-93f068df5c47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a9554cf-747d-4afb-81c0-4114eb8f8733",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6791f28b-35ca-4665-a15a-48b20096c3b8", "AQAAAAIAAYagAAAAEMLm0mO1pvcA6XaNMkH4gcD42f3Dv/MVio4Y8qO/qJXL/xLs6Qhai8wBxfPOCgLBjA==", "306486f1-67a8-4477-8e30-61e9475999ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f270bed-70c3-46c2-bd83-c47b73eb7e2d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "559e031b-2e13-438e-8327-1912af2ada83", "AQAAAAIAAYagAAAAEDkt3ReoOEgisSvL41RKSPiEZY9+PQNBIaGQm4e2KEx6L0SsovnZmRHoXbLvki4fNg==", "d74d32ad-87f0-4b40-b15e-5198e7b2ee29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "854428da-d335-45ef-a793-dced73bbff77",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7d3f5e9-40ff-43d6-bb61-21c882c40077", "AQAAAAIAAYagAAAAEPK1gyVuV1OvGr1fqVW+KKg4v7CkUQ/beo9HJb9B2lxw0bXgZRbu9mJIggTmV4UCgA==", "b11d0548-2d3a-473a-90eb-03ca2c89d2b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9668a0c8-1c05-4240-b413-18b4c4bf1873",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f802ab6b-2206-43b9-86d2-5c03c1a15c09", "AQAAAAIAAYagAAAAEBZa2fvXQ/cMxf/lheZwywu8p+x2CXYhmNDPEIuef4+ktQfXXGYCYLt0dB0q9ZGerw==", "c4fe8193-1c2c-4d37-bab1-ef217a50dc2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2f48359-0469-43b0-8654-f61b9d1ab286",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecce81c0-7cb8-4e83-8a57-2c75ae6cc8f7", "AQAAAAIAAYagAAAAEFIps5XA4aLGQ1GsHKO5rx+uDoaKPRB2aL+JgjlcIgJK9DAQZ+VW3ZacR5HrhW9lJQ==", "7530e35c-df4c-4a63-ab15-23e170a2000c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4e8abc4-dbbf-406d-8031-20509b79c1a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30f812d0-2f65-4e4d-9f20-1f9ee0b88d84", "AQAAAAIAAYagAAAAEBbr7jlUVT6pqBwOmylMkV/OM4/+OlajnCKvIiZKnRnK8qSomoYA/IAujASCJCExIQ==", "55451550-d479-430e-8e40-ca9d43f53a2e" });

            migrationBuilder.CreateIndex(
                name: "IX_Vitals_UserId",
                table: "Vitals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisit_PatientID",
                table: "DoctorVisit",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorVisit_AspNetUsers_UserId",
                table: "DoctorVisit",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorVisit_Patients_PatientID",
                table: "DoctorVisit",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vitals_AspNetUsers_UserId",
                table: "Vitals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
