using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Collections.Generic;
using VirtualHealthProject.Models;
using VirtualHealthProject.ViewModels;
using static VirtualHealthProject.Models.RequestConsumables;
using User = VirtualHealthProject.Models.User;

namespace VirtualHealthProject.Data
{
    public class VirtualHealthDbContext : IdentityDbContext<User>
    {
        public VirtualHealthDbContext(DbContextOptions<VirtualHealthDbContext> options)
            : base(options)
        {


        }

        //Ward Management
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<BedAllocation> BedAllocations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ReferralLetter> ReferralLetters { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<CurrentMedication> CurrentMedications { get; set; }
        public DbSet<ChronicIllness> ChronicIllnesses { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<PatientMovement> PatientMovements { get; set; }

        //Consumables and Scripts
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ConsumableStockLevels> ConsumableStockLevels { get; set; }
        public DbSet<RequestConsumables> RequestConsumables { get; set; }
        public DbSet<WeeklyStockTakes> WeeklyStockTakes { get; set; }
        public DbSet<InventoryHistory> InventoryHistories { get; set; }
        public DbSet<PrescriptionScript> PrescriptionScripts { get; set; }
        public DbSet<ViewConsumablesStock> viewConsumablesStocks { get; set; }


        public DbSet<DispenceMedication> dispenceMedications { get; set; }
        //public DbSet<PrescriptionPharma> prescriptionPharmas { get; set; }


        //Doctor Patient
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<NurseInstruction> NurseInstructions { get; set; }
        public DbSet<PatientVisits> PatientVisits { get; set; }
        public DbSet<Discharge> Discharges { get; set; }
        public DbSet<Vitals> Vitals { get; set; }
       
        //Patient Care
        public DbSet<DoctorVisit> DoctorVisit { get; set; }

        public DbSet<Prescription> Prescription { get; set; }

        public DbSet<NurseDispense> NurseDispense { get; set; }
        public DbSet<Billing> Billings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorVisit>()
                .HasKey(v => v.VisitId);  // This marks the entity as keyless


            modelBuilder.Entity<Vitals>()
                .HasKey(v => v.VitalsId);  // Ensure this is correctly defined

            modelBuilder.Entity<Prescription>()
                .HasNoKey();  // Mark the entity as keyless if it doesn't require a primary key


            // This is where you configure the entity mapping.
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BedAllocation>().ToTable("BedAllocation");

            modelBuilder.Entity<Bed>()
            .ToTable("Beds")
            .Property(b => b.IsOccupied)
            .HasColumnName("is_occupied")
            .HasColumnType("bit");


            modelBuilder.Entity<Prescription>()
             .HasNoKey(); // Define as keyless
            //modelBuilder.Entity<Vitals>()
            //.HasNoKey(); // Define as keyless

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            //Assigning role id to system users.
            var AdminRoleId = "04972214-ed08-4594-9db5-73c50192309c";
            var DoctorRoleId = "18ebd57b-2075-4ceb-bd1a-e888697dffed";
            var NurseRoleId = "38d828e6-c344-4ec0-b295-3000f6d5ea06";
            var PharmacistRoleId = "9fa367bc-0217-4f68-b173-57af2db76cde";
            var WardAdminRoleId = "33e37ac0-d18d-49fa-8737-27a50d419f9a";
            var ScriptManagerRoleId = "a5395c94-33d2-45f0-a65d-024ff1e18291";
            var StockManagerRoleId = "bd81ab2b-1df6-4b0e-938b-aa55f1ba5188";

            //Creating the roles.

            var roles = new List<IdentityRole>
            {
                 new IdentityRole
                 {
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR",
                     Id = AdminRoleId,
                     ConcurrencyStamp = AdminRoleId,
                 },

                 new IdentityRole
                 {
                     Name = "Doctor",
                     NormalizedName = "DOCTOR",
                     Id = DoctorRoleId,
                     ConcurrencyStamp = DoctorRoleId,
                 },

                 new IdentityRole
                 {
                     Name = "Nurse",
                     NormalizedName = "NURSE",
                     Id = NurseRoleId,
                     ConcurrencyStamp = NurseRoleId,
                 },

                 new IdentityRole
                 {
                     Name = "Pharmacist",
                     NormalizedName = "PHARMACIST",
                     Id = PharmacistRoleId,
                     ConcurrencyStamp = PharmacistRoleId,
                 },

                 new IdentityRole
                 {
                     Name = "WardAdmin",
                     NormalizedName = "WARDADMIN",
                     Id = WardAdminRoleId,
                     ConcurrencyStamp = WardAdminRoleId,
                 },

                 new IdentityRole
                 {
                     Name = "ScriptManager",
                     NormalizedName = "SCRIPTMANAGER",
                     Id = ScriptManagerRoleId,
                     ConcurrencyStamp = ScriptManagerRoleId,
                 },

                 new IdentityRole
                 {
                     Name = "StockManager",
                     NormalizedName = "STOCKMANAGER",
                     Id = StockManagerRoleId,
                     ConcurrencyStamp = StockManagerRoleId,
                 }

            };


            modelBuilder.Entity<IdentityRole>().HasData(roles);

            //Creating the admin user.
            var adminUserId = "7f270bed-70c3-46c2-bd83-c47b73eb7e2d";
            var adminUser = new User
            {
                FirstName = "Justin",
                LastName = "Fourie",
                UserName = "admin@virtualhealthbridge.com",
                Email = "admin@virtualhealthbridge.com",
                NormalizedEmail = "admin@virtualhealthbridge.com".ToUpper(),
                NormalizedUserName = "admin@virtualhealthbridge.com".ToUpper(),
                Id = adminUserId,
                
            };

            //Adding the user password.
            adminUser.PasswordHash = new PasswordHasher<User>().HashPassword(adminUser, "admin@123");

            modelBuilder.Entity<User>().HasData(adminUser);

            //wardAdmin
            var wardadminUserId = "1a9554cf-747d-4afb-81c0-4114eb8f8733";
            var wardadminUser = new User
            {
                FirstName = "Qulon",
                LastName = "Forbes",
                UserName = "wardAdmin@virtualhealthbridge.com",
                Email = "wardAdmin@virtualhealthbridge.com",
                NormalizedEmail = "wardAdmin@virtualhealthbridge.com".ToUpper(),
                NormalizedUserName = "wardAdmin@virtualhealthbridge.com".ToUpper(),
                Id = wardadminUserId,

            };

            //Adding the user password.
            wardadminUser.PasswordHash = new PasswordHasher<User>().HashPassword(wardadminUser, "wardAdmin@123");

            modelBuilder.Entity<User>().HasData(wardadminUser);

            //Pharmacist
            var pharmacistUserId = "15a39159-9060-4425-8c3e-ba218c4ca37d";
            var pharmacistUser = new User
            {
                FirstName = "Sheldon",
                LastName = "Brown",
                UserName = "pharmacist@virtualhealthbridge.com",
                Email = "pharmacist@virtualhealthbridge.com",
                NormalizedEmail = "pharmacist@virtualhealthbridge.com".ToUpper(),
                NormalizedUserName = "pharmacist@virtualhealthbridge.com".ToUpper(),
                Id = pharmacistUserId,

            };

            //Adding the user password.
            pharmacistUser.PasswordHash = new PasswordHasher<User>().HashPassword(pharmacistUser, "pharmacist@123");

            modelBuilder.Entity<User>().HasData(pharmacistUser);

            //StockManager
            var stockManagerUserId = "a2f48359-0469-43b0-8654-f61b9d1ab286";
            var stockManagerUser = new User
            {
                FirstName = "Brendon",
                LastName = "Scott",
                UserName = "stockmanager@virtualhealthbridge.com",
                Email = "stockmanager@virtualhealthbridge.com",
                NormalizedEmail = "stockmanager@virtualhealthbridge.com".ToUpper(),
                NormalizedUserName = "stockmanager@virtualhealthbridge.com".ToUpper(),
                Id = stockManagerUserId,

            };

            //Adding the user password.
            stockManagerUser.PasswordHash = new PasswordHasher<User>().HashPassword(stockManagerUser, "stockmanager@123");

            modelBuilder.Entity<User>().HasData(stockManagerUser);

            //ScriptManager
            var scriptManagerUserId = "854428da-d335-45ef-a793-dced73bbff77";
            var scriptmanagerUser = new User
            {
                FirstName = "Bongani",
                LastName = "Kunene",
                UserName = "scriptmanager@virtualhealthbridge.com",
                Email = "scriptmanager@virtualhealthbridge.com".ToUpper(),
                NormalizedEmail = "scriptmanager@virtualhealthbridge.com".ToUpper(),
                NormalizedUserName = "scriptmanager@virtualhealthbridge.com".ToUpper(),
                Id = scriptManagerUserId,
            };

            //Adding User password.
            scriptmanagerUser.PasswordHash = new PasswordHasher<User>().HashPassword(scriptmanagerUser, "script@123");

            modelBuilder.Entity<User>().HasData(scriptmanagerUser);


            //Nurse
            var nurseUserId = "9668a0c8-1c05-4240-b413-18b4c4bf1873";
            var nurseUser = new User
            {
                FirstName = "Juliet",
                LastName = "Links",
                UserName = "nurse@virtualhealthbridge.com",
                Email = "nurse@virtualhealthbridge.com".ToUpper(),
                NormalizedEmail = "nurse@virtualhealthbridge.com".ToUpper(),
                NormalizedUserName = "nurse@virtualhealthbridge.com".ToUpper(),
                Id = nurseUserId,
            };

            //Adding User password.
            nurseUser.PasswordHash = new PasswordHasher<User>().HashPassword(nurseUser, "nurse@123");

            modelBuilder.Entity<User>().HasData(nurseUser);

            //doctor
            var doctorUserId = "c4e8abc4-dbbf-406d-8031-20509b79c1a4";
            var doctorUser = new User
            {
                FirstName = "Gregory",
                LastName = "Pikk",
                UserName = "doctor@virtualhealthbridge.com",
                Email = "doctor@virtualhealthbridge.com".ToUpper(),
                NormalizedEmail = "doctor@virtualhealthbridge.com".ToUpper(),
                NormalizedUserName = "doctor@virtualhealthbridge.com".ToUpper(),
                Id = doctorUserId,
            };

            //Adding User password.
            doctorUser.PasswordHash = new PasswordHasher<User>().HashPassword(doctorUser, "doctor@123");

            modelBuilder.Entity<User>().HasData(doctorUser);


            //Adding User Roles
            var userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = AdminRoleId,
                    UserId = adminUserId,
                },

                new IdentityUserRole<string>
                {
                    RoleId = WardAdminRoleId,
                    UserId = adminUserId,
                },

                new IdentityUserRole<string>
                {
                    RoleId = PharmacistRoleId,
                    UserId = pharmacistUserId,
                },

                new IdentityUserRole<string>
                {
                    RoleId = StockManagerRoleId,
                    UserId = stockManagerUserId,
                },

                new IdentityUserRole<string>
                {
                    RoleId = NurseRoleId,
                    UserId = nurseUserId,
                },

                new IdentityUserRole<string>
                {
                    RoleId = ScriptManagerRoleId,
                    UserId = scriptManagerUserId,
                },

                new IdentityUserRole<string>
                {
                    RoleId = DoctorRoleId,
                    UserId = doctorUserId,
                }
            };

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);


        }
        public DbSet<VirtualHealthProject.Models.DispenceMedication> DispenceMedication { get; set; } = default!;
        //public DbSet<VirtualHealthProject.Models.RequestConsumables> RequestConsumables { get; set; } = default!;

        public class UserEntityConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.Property(u => u.FirstName).HasMaxLength(255);
                builder.Property(u => u.FirstName).HasMaxLength(255);
            }
        }
        public DbSet<VirtualHealthProject.Models.Admis> Admis { get; set; } = default!;
    }
}
