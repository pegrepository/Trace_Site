using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.DataContext.Checkpoints;

public partial class CheckPointsContext : DbContext
{
    public CheckPointsContext()
    {
    }

    public CheckPointsContext(DbContextOptions<CheckPointsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CheckPointsList> CheckPointsLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=N139\\SQLEXPRESS03;Initial Catalog=CheckPoints;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckPointsList>(entity =>
        {
            entity.HasKey(e => e.CheckPointId);

            entity.ToTable("CheckPointsList");

            entity.Property(e => e.CheckPointIp).HasColumnName("CheckPointIP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
