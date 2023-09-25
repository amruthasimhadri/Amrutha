using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models;

public partial class AmmuContext : DbContext
{
    public AmmuContext()
    {
    }

    public AmmuContext(DbContextOptions<AmmuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cu> Cus { get; set; }

    public virtual DbSet<Stud> Studs { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<T1> T1s { get; set; }

    public virtual DbSet<T2> T2s { get; set; }

    public virtual DbSet<Table2> Table2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ASIMHADR-L-5515\\SQLEXPRESS;Initial Catalog=Ammu;User ID=sa;Password=Welcome2evoke@1234;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cu>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cus");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("salary");
        });

        modelBuilder.Entity<Stud>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stud");

            entity.Property(e => e.College)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Student");

            entity.Property(e => e.Ca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ca");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Pa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pa");
            entity.Property(e => e.Rno).HasColumnName("rno");
        });

        modelBuilder.Entity<T1>(entity =>
        {
            entity.ToTable("t1");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<T2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("t2");

            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Table2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Table2");

            entity.Property(e => e.DeptId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("dept_id");
            entity.Property(e => e.DeptName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("dept_name");
            entity.Property(e => e.Head)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("head");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
