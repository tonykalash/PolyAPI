using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PolyAPI.Models
{
    public partial class polyclinic_kalashnikovContext : DbContext
    {
        public polyclinic_kalashnikovContext()
        {
        }

        public polyclinic_kalashnikovContext(DbContextOptions<polyclinic_kalashnikovContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ambulance> Ambulances { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Diagnosis> Diagnoses { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Price> Prices { get; set; } = null!;
        public virtual DbSet<Pschedule> Pschedules { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Speciality> Specialities { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=81.177.6.104,1433; Database=polyclinic_kalashnikov; User ID=is221; Password = Student1234; Trusted_Connection=False; Integrated Security=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ambulance>(entity =>
            {
                entity.HasKey(e => e.AmbId);

                entity.ToTable("Ambulance");

                entity.Property(e => e.AmbId)
                    .ValueGeneratedNever()
                    .HasColumnName("amb_id");

                entity.Property(e => e.AmbAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("amb_address");

                entity.Property(e => e.AmbDate)
                    .HasColumnType("date")
                    .HasColumnName("amb_date");

                entity.Property(e => e.AmbTime).HasColumnName("amb_time");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientCardId).HasColumnName("patient_card_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Ambulances)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ambulance_Doctors");

                entity.HasOne(d => d.PatientCard)
                    .WithMany(p => p.Ambulances)
                    .HasPrincipalKey(p => p.PatientCardId)
                    .HasForeignKey(d => d.PatientCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ambulance_Patients");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedNever()
                    .HasColumnName("booking_id");

                entity.Property(e => e.BookingDescription)
                    .HasColumnType("text")
                    .HasColumnName("booking_description");

                entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientCardId).HasColumnName("patient_card_id");

                entity.Property(e => e.PriceId).HasColumnName("price_id");

                entity.HasOne(d => d.Diagnosis)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.DiagnosisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Diagnosis");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Doctors");

                entity.HasOne(d => d.PatientCard)
                    .WithMany(p => p.Bookings)
                    .HasPrincipalKey(p => p.PatientCardId)
                    .HasForeignKey(d => d.PatientCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Booking");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Price");
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.ToTable("Diagnosis");

                entity.Property(e => e.DiagnosisId)
                    .ValueGeneratedNever()
                    .HasColumnName("diagnosis_id");

                entity.Property(e => e.DiagnosisCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("diagnosis_code");

                entity.Property(e => e.DiagnosisDescription)
                    .HasColumnType("text")
                    .HasColumnName("diagnosis_description");

                entity.Property(e => e.DiagnosisName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("diagnosis_name");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId)
                    .ValueGeneratedNever()
                    .HasColumnName("doctor_id");

                entity.Property(e => e.DoctorCategory)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("doctor_category");

                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK_Doctors_Speciality");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.PatientCardId, "IX_Patients")
                    .IsUnique();

                entity.Property(e => e.PatientId)
                    .ValueGeneratedNever()
                    .HasColumnName("patient_id");

                entity.Property(e => e.PatientAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("patient_address");

                entity.Property(e => e.PatientBirthdate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patient_birthdate");

                entity.Property(e => e.PatientCardId).HasColumnName("patient_card_id");

                entity.Property(e => e.PatientCardLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patient_card_location");

                entity.Property(e => e.PatientDiscount).HasColumnName("patient_discount");

                entity.Property(e => e.PatientGender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("patient_gender")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price");

                entity.Property(e => e.PriceId)
                    .ValueGeneratedNever()
                    .HasColumnName("price_id");

                entity.Property(e => e.PriceDescription)
                    .HasColumnType("text")
                    .HasColumnName("price_description");

                entity.Property(e => e.PriceName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("price_name");
            });

            modelBuilder.Entity<Pschedule>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PSchedule");

                entity.Property(e => e.PscheduleDate)
                    .HasColumnType("date")
                    .HasColumnName("pschedule_date");

                entity.Property(e => e.PscheduleTime).HasColumnName("pschedule_time");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.ToTable("Schedule");

                entity.Property(e => e.DoctorId)
                    .ValueGeneratedNever()
                    .HasColumnName("doctor_id");

                entity.Property(e => e.ScheduleDate)
                    .HasColumnType("date")
                    .HasColumnName("schedule_date");

                entity.Property(e => e.ScheduleTime).HasColumnName("schedule_time");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("Speciality");

                entity.Property(e => e.SpecialityId)
                    .ValueGeneratedNever()
                    .HasColumnName("speciality_id");

                entity.Property(e => e.SpecialityName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("speciality_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.UserLogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_login");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
