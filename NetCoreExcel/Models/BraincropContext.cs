using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NetCoreExcel.Models;

public partial class BraincropContext : DbContext
{
    public BraincropContext()
    {
    }

    public BraincropContext(DbContextOptions<BraincropContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AHMED-PC\\SQLEXPRESS;Database=Braincrop;Trusted_Connection=True;TrustServerCertificate=True;", x => x.UseNetTopologySuite());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_MobileUserIdentity");

            entity.ToTable("AppUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Zipcode)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(d => d.Employers).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AppUserEmployer",
                    r => r.HasOne<Employer>().WithMany()
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("AppUser_Employer_Employer"),
                    l => l.HasOne<AppUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("AppUser_Employer_AppUser"),
                    j =>
                    {
                        j.HasKey("UserId", "EmployerId");
                        j.ToTable("AppUser_Employer");
                    });
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.ToTable("Employer");

            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("createdOn");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
