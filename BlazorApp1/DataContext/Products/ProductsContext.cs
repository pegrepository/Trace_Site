﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.DataContext.Products;

public partial class ProductsContext : DbContext
{
    public ProductsContext()
    {
    }

    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductLabels> ProductLabels { get; set; }

    public virtual DbSet<ProductPackingLists> ProductPackingLists { get; set; }

    public virtual DbSet<ProductPassports> ProductPassports { get; set; }

    public virtual DbSet<ProductSettings> ProductSettings { get; set; }

    public virtual DbSet<ProductTags> ProductTags { get; set; }

    public virtual DbSet<ProductTagParameters> ProductTagParameters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=N139\\SQLEXPRESS03;Initial Catalog=Products;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductLabels>(entity =>
        {
            entity.HasKey(e => e.LabelId);
        });

        modelBuilder.Entity<ProductPackingLists>(entity =>
        {
            entity.HasKey(e => e.PackingListId);
        });

        modelBuilder.Entity<ProductPassports>(entity =>
        {
            entity.HasKey(e => e.PassportId);
        });

        modelBuilder.Entity<ProductSettings>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_ProductSettings_1");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.ProductDataJson).HasComment("В столбце \"ProductDataJson\" содержится:\r\n1. LastSerial\r\n2. Prefix\r\n");
            entity.Property(e => e.ProductSettingsJson).HasComment("В столбце \"ProductDataJson\" содержится:\r\n1. LastSerial\r\n2. Prefix\r\n");

            entity.HasOne(d => d.ProductTag).WithMany(p => p.ProductSettings)
                .HasForeignKey(d => d.ProductTagId)
                .HasConstraintName("FK_ProductSettings_ProductTags");
        });

        modelBuilder.Entity<ProductTags>(entity =>
        {
            entity.HasKey(e => e.TagId);

            entity.HasOne(d => d.TagLabel).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.TagLabelId)
                .HasConstraintName("FK_ProductTags_ProductLabels");

            entity.HasOne(d => d.TagPackingList).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.TagPackingListId)
                .HasConstraintName("FK_ProductTags_ProductPackingLists");

            entity.HasOne(d => d.TagParameters).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.TagParametersId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ProductTags_ProductTagParameters");

            entity.HasOne(d => d.TagPassport).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.TagPassportId)
                .HasConstraintName("FK_ProductTags_ProductPassports");
        });

        modelBuilder.Entity<ProductTagParameters>(entity =>
        {
            entity.HasKey(e => e.ParametersId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
