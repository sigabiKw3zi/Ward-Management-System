using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualHealthProject.Migrations
{
    /// <inheritdoc />
    public partial class Localtest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisit_AspNetUsers_UserId",
                table: "DoctorVisit");

            migrationBuilder.DropIndex(
                name: "IX_DoctorVisit_UserId",
                table: "DoctorVisit");

            migrationBuilder.DropColumn(
                name: "AdmissionDate",
                table: "DoctorVisit");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "DoctorVisit");

            migrationBuilder.DropColumn(
                name: "IsAdmitted",
                table: "DoctorVisit");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "DoctorVisit");

            migrationBuilder.DropColumn(
                name: "Prescription",
                table: "DoctorVisit");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DoctorVisit");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "DoctorVisit",
                newName: "ScheduleVMedication");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "DoctorVisit",
                newName: "ScheduleIVMedication");

            migrationBuilder.AlterColumn<string>(
                name: "scheduleVMedications",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "scheduleIVMedications",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "VitalsId",
                table: "Vitals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Temperature",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduleMedication",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PulseRate",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PainLevel",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BloodPressure",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "DoctorVisit",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ChronicConditionsStatus",
                table: "DoctorVisit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vitals",
                table: "Vitals",
                column: "VitalsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorVisit",
                table: "DoctorVisit",
                column: "VisitId");

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledMedication = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BedCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicationCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.BillId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15a39159-9060-4425-8c3e-ba218c4ca37d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f820a22b-4a6b-4564-bef3-62db7d0ed1f2", "AQAAAAIAAYagAAAAEF7wYPCatLg9tehkqeYtoSqNSex9I4mLAnVuxCUzDaX3dYCzumLn3anNdfVifdzb8A==", "0a06311e-c643-4a17-ab2c-9e29b7499f3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a9554cf-747d-4afb-81c0-4114eb8f8733",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "324e7a39-3ffd-44a6-9b93-2570fcc4c8a7", "AQAAAAIAAYagAAAAEOvJJX2J8s2ghF7Z2cewj0LENK9VY2Z9WOvKVkI8ffFzzLrmpXU22zJv6HP4hyi07A==", "ae945918-5f99-4769-a9ba-42353e5fcec4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f270bed-70c3-46c2-bd83-c47b73eb7e2d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7ead30d-c0ba-4dcd-b45a-ee108014240d", "AQAAAAIAAYagAAAAEOGCPXcTN646bJZTiDm/KnCk6Tq82jjEZxT97E6XM2nYoQqq+h5Idzu9oocXFYwC+Q==", "0e0bb1ad-1dd2-495f-a7c1-62bd495a95f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "854428da-d335-45ef-a793-dced73bbff77",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba9a0f3f-427e-4913-b63a-8795a508c060", "AQAAAAIAAYagAAAAECQuqv1qG8DSe1D9wwSzNX7gcHNa2ICvu2WrCBR9FceHXRLFXAonDCFROn0SglL+hg==", "d07c94c9-338a-4ae2-a189-bc11928fd49c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9668a0c8-1c05-4240-b413-18b4c4bf1873",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b89a3ba-1c66-4a34-959b-4e97cfa147c1", "AQAAAAIAAYagAAAAEGluucIf01HfhSTjg2+5df7SL9DOqGkFjlAoGffmDhE62pyOnGZvius6/91md/pgZQ==", "2148b24e-6f80-4399-a21e-8461e47ee9e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2f48359-0469-43b0-8654-f61b9d1ab286",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ff366a3-96d4-4f51-b702-2ac81649f07d", "AQAAAAIAAYagAAAAEMKPQ8dC9eesbVUo+409cIq44qm1xr1b3K3nFnX9Hd89MuMan/iqwTbCMwYCTlI6dQ==", "d8c84497-bb6f-4ab0-8a2a-dcafee3e7d02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4e8abc4-dbbf-406d-8031-20509b79c1a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e5db233-b7ab-4fbe-98f4-ff347280d366", "AQAAAAIAAYagAAAAEIGgQkExzOYOc2bHl0j+KeDOBfY9HLpZ66il3WIo9mvfnuAIhhLOndQ3Kx1EyQ+8yQ==", "5df06f13-3696-4c99-a683-83eb0f4d4a67" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vitals",
                table: "Vitals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorVisit",
                table: "DoctorVisit");

            migrationBuilder.DropColumn(
                name: "ChronicConditionsStatus",
                table: "DoctorVisit");

            migrationBuilder.RenameColumn(
                name: "ScheduleVMedication",
                table: "DoctorVisit",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "ScheduleIVMedication",
                table: "DoctorVisit",
                newName: "Notes");

            migrationBuilder.AlterColumn<string>(
                name: "scheduleVMedications",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "scheduleIVMedications",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Temperature",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ScheduleMedication",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PulseRate",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PainLevel",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BloodPressure",
                table: "Vitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VitalsId",
                table: "Vitals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "DoctorVisit",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "AdmissionDate",
                table: "DoctorVisit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Instructions",
                table: "DoctorVisit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmitted",
                table: "DoctorVisit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "DoctorVisit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Prescription",
                table: "DoctorVisit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DoctorVisit",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15a39159-9060-4425-8c3e-ba218c4ca37d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78fa497c-c2db-4a1e-bfad-1eacb4a38b73", "AQAAAAIAAYagAAAAEETdrbekXWp7oSmbtRi361HmsOw8mAiy49eO7ACCNtu0welLz1g1INUbcASM13dDoQ==", "f256abf5-2a68-4342-a7b6-b4dda356ecc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a9554cf-747d-4afb-81c0-4114eb8f8733",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f3f7eda-8f2a-4e26-876b-13c93437cc96", "AQAAAAIAAYagAAAAEFENeR9mHW2J1XPZki9pXG5wOGqrxLdqhJ7elk2/22QQH1rPo/vEeHkuN6vNUX6dGA==", "7a2db0d7-fbcf-4bb3-aac8-c0431c71734f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f270bed-70c3-46c2-bd83-c47b73eb7e2d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7f5780e-825b-453d-afb3-4135337c341d", "AQAAAAIAAYagAAAAEMWvGTBSXK1dk0lRKoYfqp6XjLe1orny2seo0i4nddW4saKNN8SUNCgtBsQXzWyi7A==", "b1baf3be-e6b2-4a5e-b3cf-497fb948d18e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "854428da-d335-45ef-a793-dced73bbff77",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1e3b8b5-3b0b-4e36-bf92-7690e631fa47", "AQAAAAIAAYagAAAAEMM6iam4dlPCrt3isjQv0cZDejxQtMQtGWv4Wjf1w2W4E0YMfWU1nKoeNheNyd3WdA==", "d4890ffa-80d1-4cf0-991b-cfc001ae5c36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9668a0c8-1c05-4240-b413-18b4c4bf1873",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4e52701-b64a-48e3-89c2-205245dc25e5", "AQAAAAIAAYagAAAAEN2SnzfvdrQZTvRcabnHL0UffhDrxAIhD9oSOlhrBhMED5xnL6o07o5bz5TlxT68gQ==", "06bf5c8c-835f-4dcb-8e74-6d4395318632" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2f48359-0469-43b0-8654-f61b9d1ab286",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20cec6f6-5019-4716-bfb8-b3d0fd0d1449", "AQAAAAIAAYagAAAAEOPwG1cB1/opxN103TL1LaB9XxK8VWx6iML3Ay/jhx2BD0tCrZZxY6LeaqrMAYMoEw==", "05b023ce-0259-4066-9fdb-e5f831709e58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4e8abc4-dbbf-406d-8031-20509b79c1a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e1f2df3-84aa-4528-a959-21f1b546dae1", "AQAAAAIAAYagAAAAEN1sloH94GSD3LcqY/ZUMiX6A9EQjYLsjZZWwB+pEE9mYSzaerc1vqEukmUc8CU75Q==", "9efd0124-5fb8-4cfe-8202-134709a8f0ef" });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisit_UserId",
                table: "DoctorVisit",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorVisit_AspNetUsers_UserId",
                table: "DoctorVisit",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
