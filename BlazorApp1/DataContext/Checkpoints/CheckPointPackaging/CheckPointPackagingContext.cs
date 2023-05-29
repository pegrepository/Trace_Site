using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.DataContext.Checkpoints.CheckPointPackaging;

public partial class CheckPointPackagingContext : DbContext
{
    public CheckPointPackagingContext()
    {
    }

    public CheckPointPackagingContext(DbContextOptions<CheckPointPackagingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CheckPointDataPackages> CheckPointDataPackages { get; set; }

    public virtual DbSet<CheckPointDataSerials> CheckPointDataSerials { get; set; }

    public virtual DbSet<CheckPointData> CheckPointData { get; set; }

    public virtual DbSet<CheckPointSetting> CheckPointSettings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=N139\\SQLEXPRESS03;Initial Catalog=CheckPoint_Packaging;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckPointDataPackages>(entity =>
        {
            entity.HasKey(e => e.BarCode);

            entity.Property(e => e.BarCode).HasMaxLength(400);
            entity.Property(e => e.PackageSerial).HasMaxLength(400);

            entity.HasOne(d => d.PackageSerialNavigation).WithMany(p => p.CheckPointDataPackages)
                .HasPrincipalKey(p => p.Serial)
                .HasForeignKey(d => d.PackageSerial)
                .HasConstraintName("FK_CheckPointDataPackages_CheckPointDataSerials");
        });

        modelBuilder.Entity<CheckPointDataSerials>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_YourTable");

            entity.HasIndex(e => e.Serial, "IX_CheckPointDataSerials").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Serial).HasMaxLength(400);
        });

        modelBuilder.Entity<CheckPointData>(entity =>
        {
            entity.HasKey(e => e.IdAndBarCode);

            entity.Property(e => e.IdAndBarCode).HasMaxLength(400);
            entity.Property(e => e.BarCode).HasMaxLength(400);
            entity.Property(e => e.Imei).HasColumnName("IMEI");
            entity.Property(e => e.PackData).HasColumnType("datetime");

            entity.HasOne(d => d.BarCodeNavigation).WithMany(p => p.CheckPointData)
                .HasForeignKey(d => d.BarCode)
                .HasConstraintName("FK_CheckPointData_CheckPointDataPackages");
        });

        modelBuilder.Entity<CheckPointSetting>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.Property(e => e.ProductId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
