using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.DataBase.NewMesContext;

public partial class NewMes : DbContext
{
    public NewMes()
    {
    }

    public NewMes(DbContextOptions<NewMes> options)
        : base(options)
    {
    }

    public virtual DbSet<Mes> Mes { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Pg> Pgs { get; set; }

    public virtual DbSet<Printer> Printers { get; set; }

    public virtual DbSet<Ufk1> Ufk1 { get; set; }

    public virtual DbSet<Ufk3> Ufk3 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=N139\\Sqlexpress03;Initial Catalog=NewMes;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mes>(entity =>
        {
            entity.HasKey(e => e.BarCode).HasName("PK_dbo.MES");

            entity.ToTable("MES");

            entity.Property(e => e.BarCode).HasMaxLength(128);
            entity.Property(e => e.TimeCheck).HasColumnType("datetime");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Pg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.PGs");

            entity.ToTable("PGs");

            entity.HasIndex(e => e.MesBarCode, "IX_Mes_BarCode");

            entity.Property(e => e.MesBarCode)
                .HasMaxLength(128)
                .HasColumnName("Mes_BarCode");
            entity.Property(e => e.TimeStart).HasColumnType("datetime");
            entity.Property(e => e.TimeStop).HasColumnType("datetime");

            entity.HasOne(d => d.MesBarCodeNavigation).WithMany(p => p.Pgs)
                .HasForeignKey(d => d.MesBarCode)
                .HasConstraintName("FK_dbo.PGs_dbo.MES_Mes_BarCode");
        });

        modelBuilder.Entity<Printer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.PRINTERs");

            entity.ToTable("PRINTERs");

            entity.HasIndex(e => e.BarCode, "IX_BarCode");

            entity.Property(e => e.BarCode).HasMaxLength(128);
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.BarCodeNavigation).WithMany(p => p.Printers)
                .HasForeignKey(d => d.BarCode)
                .HasConstraintName("FK_dbo.PRINTERs_dbo.MES_BarCode");
        });

        modelBuilder.Entity<Ufk1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.UFK1");

            entity.ToTable("UFK1");

            entity.HasIndex(e => e.MesBarCode, "IX_Mes_BarCode");

            entity.Property(e => e.Jsontest).HasColumnName("JSONTest");
            entity.Property(e => e.MesBarCode)
                .HasMaxLength(128)
                .HasColumnName("Mes_BarCode");
            entity.Property(e => e.TimeStart).HasColumnType("datetime");
            entity.Property(e => e.TimeStop).HasColumnType("datetime");
            entity.Property(e => e.Vch).HasColumnName("VCh");

            entity.HasOne(d => d.MesBarCodeNavigation).WithMany(p => p.Ufk1)
                .HasForeignKey(d => d.MesBarCode)
                .HasConstraintName("FK_dbo.UFK1_dbo.MES_Mes_BarCode");
        });

        modelBuilder.Entity<Ufk3>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.UFK3");

            entity.ToTable("UFK3");

            entity.HasIndex(e => e.MesBarCode, "IX_Mes_BarCode");

            entity.Property(e => e.Iccid).HasColumnName("ICCID");
            entity.Property(e => e.Jsontest).HasColumnName("JSONTest");
            entity.Property(e => e.MesBarCode)
                .HasMaxLength(128)
                .HasColumnName("Mes_BarCode");
            entity.Property(e => e.TimeStart).HasColumnType("datetime");
            entity.Property(e => e.TimeStop).HasColumnType("datetime");

            entity.HasOne(d => d.MesBarCodeNavigation).WithMany(p => p.Ufk3)
                .HasForeignKey(d => d.MesBarCode)
                .HasConstraintName("FK_dbo.UFK3_dbo.MES_Mes_BarCode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public byte[] DownloadFile(ICollection<MesSelected> mesSelecteds)
    {
        //if(mesSelecteds == null)
        //{
        //    return null;
        //}
        //var JsonSerelis = JsonConvert.SerializeObject(mesSelecteds);
        //var data = JsonConvert.DeserializeObject<DataTable>(JsonSerelis);
        //IWorkbook workbook = new XSSFWorkbook();
        //ISheet excelSheet = workbook.CreateSheet("MES");
        //List<string> columns = new List<string>();
        //IRow row = excelSheet.CreateRow(0);
        //int columnIndex = 0;
        //foreach (System.Data.DataColumn column in data.Columns)
        //{
        //    columns.Add(column.ColumnName);
        //    row.CreateCell(columnIndex).SetCellValue(column.ColumnName);
        //    columnIndex++;
        //}
        //int rowIndex = 1;
        //foreach (DataRow dsrow in data.Rows)
        //{
        //    row = excelSheet.CreateRow(rowIndex);
        //    int cellIndex = 0;
        //    foreach (String col in columns)
        //    {
        //        row.CreateCell(cellIndex).SetCellValue(dsrow[col].ToString());
        //        cellIndex++;
        //    }
        //    rowIndex++;
        //}
        //var stream = new MemoryStream();
        //workbook.Write(stream);
        //return stream.ToArray();
        return new byte[] { 1 };
    }
}
