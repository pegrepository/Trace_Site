using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.DataContext.Permissions;

public partial class PermissionsContext : DbContext
{
    public PermissionsContext()
    {
    }

    public PermissionsContext(DbContextOptions<PermissionsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeesList> EmployeesList { get; set; }

    public virtual DbSet<PermissionRules> PermissionRules { get; set; }

    public virtual DbSet<PermissionsList> PermissionsList { get; set; }

    public virtual DbSet<WebSitePagesList> WebSitePagesList { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=N139\\SQLEXPRESS03;Initial Catalog=Permissions;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeesList>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.ToTable("EmployeesList");
        });

        modelBuilder.Entity<PermissionRules>(entity =>
        {
            entity.HasKey(e => e.RuleId);

            entity.Property(e => e.PermissionId).HasDefaultValueSql("((2))");

            entity.HasOne(d => d.Employee).WithMany(p => p.PermissionRules)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermissionRules_EmployeesList");

            entity.HasOne(d => d.Permission).WithMany(p => p.PermissionRules)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermissionRules_PermissionsList");

            entity.HasOne(d => d.WebSitePage).WithMany(p => p.PermissionRules)
                .HasForeignKey(d => d.WebSitePageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermissionRules_WebSitePagesList");
        });

        modelBuilder.Entity<PermissionsList>(entity =>
        {
            entity.HasKey(e => e.PermissionId);

            entity.ToTable("PermissionsList");
        });

        modelBuilder.Entity<WebSitePagesList>(entity =>
        {
            entity.HasKey(e => e.WebSitePageId);

            entity.ToTable("WebSitePagesList");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
public class UserPermissions
{
    public List<Rule> rulesList { get; set; } = null;

    /// <summary>
    /// Класс для передачи данных авторизации на страницу 
    /// </summary>
    public class Rule
    {
        public int RuleId { get; set; }
        public string RuleName { get; set; }
        public string PermissionLevel { get; set; }
        public bool PermissionResult { get; set; }
    }

    /// <summary>
    /// Авторизация на сайте
    /// </summary>
    /// <param name="UserName"></param>
    /// <param name="PageName"></param>
    public UserPermissions(string UserName, string PageName)
    {
        rulesList = PermissionState(UserName, PageName);
    }

    /// <summary>
    /// Проверка уровня доступа пользователя
    /// </summary>
    /// <param name="UserName"></param>
    /// <param name="PageName"></param>
    /// <returns></returns>
    public List<Rule> PermissionState(string UserName, string PageName)
    {
        Stopwatch watcher = new Stopwatch();
        watcher.Start();
        List<Rule> rulesList = new List<Rule>();



        using (PermissionsContext db = new PermissionsContext())
        {

            List<PermissionRules> rules = db.PermissionRules.
                Where(r => r.EmployeeId == db.EmployeesList.Where(e => e.EmployeeLogin == UserName).Select(e => e.EmployeeId).FirstOrDefault()).
                Where(p => p.WebSitePageId == db.WebSitePagesList.Where(p => p.WebSitePageName == PageName).Select(p => p.WebSitePageId).FirstOrDefault()).
                Include(e => e.Employee).Include(p => p.WebSitePage).Include(r => r.Permission).ToList();

            watcher.Stop();
            long watc = watcher.ElapsedMilliseconds;
            //Если найдено хоть одно правило для пользователя 
            if (rules.Count != 0)
            {
                foreach (var rule in rules)
                {
                    rulesList.Add(new Rule
                    {
                        RuleId = rule.RuleId,
                        RuleName = rule.RuleName,
                        PermissionLevel = rule.Permission.PermissionLevel,
                        PermissionResult = true
                    });
                }
            }
            //Если правил не найдено
            else
            {
                //Если пользователь отсутствует в БД
                if (db.EmployeesList.Where(e => e.EmployeeLogin == UserName).FirstOrDefault() == null)
                {
                    db.Add(new PermissionRules
                    {
                        RuleName = DateTime.Now.ToString("G"),
                        PermissionId = 2,
                        Employee = new EmployeesList { EmployeeLogin = UserName, EmployeeName = UserName },
                        WebSitePageId = db.WebSitePagesList.Where(p => p.WebSitePageName == PageName).Select(p => p.WebSitePageId).FirstOrDefault()
                    });
                }
                //Создание дефолтного правила для уже существующего пользователя
                else
                {
                    if (UserName== @"ITL-NPP\shermatov")
                    {
                        db.Add(new PermissionRules
                        {
                            RuleName = DateTime.Now.ToString("G"),
                            PermissionId = 1,
                            Employee = db.EmployeesList.Where(e => e.EmployeeLogin == UserName).FirstOrDefault(),
                            WebSitePageId = db.WebSitePagesList.Where(p => p.WebSitePageName == PageName).Select(p => p.WebSitePageId).FirstOrDefault()
                        });
                    }
                    else
                    {
                        db.Add(new PermissionRules
                        {
                            RuleName = DateTime.Now.ToString("G"),
                            PermissionId = 2,
                            Employee = db.EmployeesList.Where(e => e.EmployeeLogin == UserName).FirstOrDefault(),
                            WebSitePageId = db.WebSitePagesList.Where(p => p.WebSitePageName == PageName).Select(p => p.WebSitePageId).FirstOrDefault()
                        });
                    }
                }
                db.SaveChanges();

                //Формируем инстанс для страницы если только что создали правило
                rulesList.Add(new Rule
                {
                    RuleId = 0,
                    RuleName = DateTime.Now.ToString("G"),
                    PermissionLevel = "User",
                    PermissionResult = true
                });
                watcher.Stop();
                long watch1 = watcher.ElapsedMilliseconds;
            }
            watcher.Stop();
            long watch = watcher.ElapsedMilliseconds;
            return rulesList;
        }
    }
}