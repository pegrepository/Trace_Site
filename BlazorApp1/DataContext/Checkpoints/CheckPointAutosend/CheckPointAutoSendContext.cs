﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.DataContext.Checkpoints.CheckPointAutosend;

public partial class CheckPointAutoSendContext : DbContext
{
    public CheckPointAutoSendContext()
    {
    }

    public CheckPointAutoSendContext(DbContextOptions<CheckPointAutoSendContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CheckPointSetting> CheckPointSettings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=N139\\SQLEXPRESS03;Initial Catalog=CheckPoint_AutoSend;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckPointSetting>(entity =>
        {
            entity.HasKey(e => e.ProgramId);

            entity.Property(e => e.ProgramId).ValueGeneratedNever();
            entity.Property(e => e.PreviousSend).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
