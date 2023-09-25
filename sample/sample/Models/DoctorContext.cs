using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sample.Models;

public partial class DoctorContext : DbContext
{
    public DoctorContext()
    {
    }

    public DoctorContext(DbContextOptions<DoctorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppointmentTable> AppointmentTables { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<DoctorDetail> DoctorDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ASIMHADR-L-5515\\SQLEXPRESS;Initial Catalog=Doctor;User ID=sa;Password=Welcome2evoke@1234;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppointmentTable>(entity =>
        {
            entity.HasKey(e => e.AppointmentId);

            entity.ToTable("Appointment_Table");

            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.AppointmentTime)
                .HasColumnType("datetime")
                .HasColumnName("Appointment_Time");
            entity.Property(e => e.DoctorAvailableTime)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Doctor_Available_Time");
            entity.Property(e => e.DoctorToVisit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Doctor_To_Visit");
            entity.Property(e => e.MedicalIssue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Medical_Issue");
            entity.Property(e => e.PatientName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MedicalIssueNavigation).WithMany(p => p.AppointmentTables)
                .HasForeignKey(d => d.MedicalIssue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Table_Diseases");
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasKey(e => e.DiseasesName);

            entity.Property(e => e.DiseasesName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DiseasesId).HasColumnName("DiseasesID");

            entity.HasOne(d => d.SuitableDoctorNavigation).WithMany(p => p.Diseases)
                .HasForeignKey(d => d.SuitableDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Diseases_Doctor_Details");
        });

        modelBuilder.Entity<DoctorDetail>(entity =>
        {
            entity.HasKey(e => e.DoctorId);

            entity.ToTable("Doctor_Details");

            entity.Property(e => e.DoctorId)
                .ValueGeneratedNever()
                .HasColumnName("DoctorID");
            entity.Property(e => e.EndTime).HasColumnName("end_Time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Qualification)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Specialised)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartTime).HasColumnName("start_Time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
