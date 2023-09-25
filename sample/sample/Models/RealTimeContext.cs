using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sample.Models;

public partial class RealTimeContext : DbContext
{
    public RealTimeContext()
    {
    }

    public RealTimeContext(DbContextOptions<RealTimeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Information> Information { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ASIMHADR-L-5515\\SQLEXPRESS;Initial Catalog=RealTime;User ID=sa;\nPassword=Welcome2evoke@1234;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Information>(entity =>
        {
            entity.HasKey(e => e.CustomerName);

            entity.ToTable("information");

            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CalculatedAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("calculated_amount");
            entity.Property(e => e.DueDate)
                .HasColumnType("date")
                .HasColumnName("due_date");
            entity.Property(e => e.LoanStartedDate)
                .HasColumnType("date")
                .HasColumnName("loan_started_date");
            entity.Property(e => e.NoOfYears)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("no.of.years");
            entity.Property(e => e.Principal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("principal");
            entity.Property(e => e.RateOfInterest)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("rate_of_interest");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
