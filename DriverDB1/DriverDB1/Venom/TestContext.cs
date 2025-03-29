using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DriverDB1.Venom;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;uid=root;database=test;pwd=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.23-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("drivers");

            entity.HasIndex(e => e.PhotoId, "photoId_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Guid)
                .HasMaxLength(45)
                .HasColumnName("guid");
            entity.Property(e => e.LivingAddress)
                .HasMaxLength(45)
                .HasColumnName("livingAddress");
            entity.Property(e => e.LivingCity)
                .HasMaxLength(45)
                .HasColumnName("livingCity");
            entity.Property(e => e.MobPhone)
                .HasMaxLength(45)
                .HasColumnName("mobPhone")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(45)
                .HasColumnName("passportNumber");
            entity.Property(e => e.PassportSerial)
                .HasMaxLength(45)
                .HasColumnName("passportSerial");
            entity.Property(e => e.Patronimic)
                .HasMaxLength(45)
                .HasColumnName("patronimic");
            entity.Property(e => e.PhotoId)
                .HasColumnType("int(11)")
                .HasColumnName("photoId");
            entity.Property(e => e.RegistrationAddress)
                .HasMaxLength(45)
                .HasColumnName("registrationAddress");
            entity.Property(e => e.RegistrationCity)
                .HasMaxLength(45)
                .HasColumnName("registrationCity");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
            entity.Property(e => e.WorkPlace)
                .HasMaxLength(45)
                .HasColumnName("workPlace");
            entity.Property(e => e.WorkRole)
                .HasMaxLength(45)
                .HasColumnName("workRole");

            entity.HasOne(d => d.Photo).WithOne(p => p.Driver)
                .HasForeignKey<Driver>(d => d.PhotoId)
                .HasConstraintName("photoFR");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("photos");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Photo1)
                .HasColumnType("blob")
                .HasColumnName("photo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
