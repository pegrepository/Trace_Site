using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.DataBase.PackDataBase;

public partial class UpackageContext : DbContext
{
    public UpackageContext()
    {
    }

    public UpackageContext(DbContextOptions<UpackageContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PackDataBase> PackDatabases { get; set; }

    public virtual DbSet<PackageSerial> PackageSerials { get; set; }

    public virtual DbSet<ProductsInPackage> ProductsInPackages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress03;Initial Catalog=UPackage;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PackDataBase>(entity =>
        {
            entity.HasKey(e => e.IdAndBarCode);

            entity.ToTable("PackDataBase");

            entity.Property(e => e.Imei).HasColumnName("IMEI");
        });

        modelBuilder.Entity<PackageSerial>(entity =>
        {
            entity.HasKey(e => e.Serial);

            entity.Property(e => e.Serial).HasMaxLength(100);
            entity.Property(e => e.Date).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductsInPackage>(entity =>
        {
            entity.HasKey(e => e.BarCode);

            entity.ToTable("ProductsInPackage");

            entity.Property(e => e.BarCode).HasMaxLength(100);
            entity.Property(e => e.PackageSerial).HasMaxLength(100);

            entity.HasOne(d => d.PackageSerialNavigation).WithMany(p => p.ProductsInPackages)
                .HasForeignKey(d => d.PackageSerial)
                .HasConstraintName("FK_ProductsInPackage_PackageSerials");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
