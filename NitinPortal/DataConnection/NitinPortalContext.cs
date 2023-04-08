using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NitinPortal.DataConnection;

public partial class NitinPortalContext : DbContext
{
    public NitinPortalContext()
    {
    }

    public NitinPortalContext(DbContextOptions<NitinPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adopractice> Adopractices { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Demo> Demos { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employee1> Employees1 { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonAuditTest> PersonAuditTests { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-94NN4I6;Initial Catalog=NitinPortal;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adopractice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ADOPract__3214EC076A56D4B0");

            entity.ToTable("ADOPractice");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JoinDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Join Date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__CB48C095D98ACB58");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("City Id");
            entity.Property(e => e.CityName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("City Name");
            entity.Property(e => e.StateId).HasColumnName("State Id");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__City__State Id__49C3F6B7");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__B3170DE15FF2F3DD");

            entity.ToTable("Country");

            entity.Property(e => e.CountryId).HasColumnName("Country Id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Country Name");
        });

        modelBuilder.Entity<Demo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Demo");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07CA434A98");

            entity.ToTable("Employee", tb => tb.HasTrigger("trDeletePerson"));

            entity.Property(e => e.City)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .IsUnicode(false)
                .HasColumnName("Company Name");
            entity.Property(e => e.Country)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC079BBB99BB");

            entity.ToTable("Employees");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImagePath)
                .IsUnicode(false)
                .HasColumnName("Image Path");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NewImagePath)
                .IsUnicode(false)
                .HasColumnName("New Image Path");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Images__2CEF5B349B8E2DB5");

            entity.Property(e => e.ImageId).HasColumnName("Image Id");
            entity.Property(e => e.Extension)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FilePath)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("File Path");
            entity.Property(e => e.FileSize)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("File Size");
            entity.Property(e => e.FileType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("File Type");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC07928041E2");

            entity.ToTable("Person", tb => tb.HasTrigger("trInsertPerson"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Gender)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PersonAuditTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Person_Audit_Test");

            entity.Property(e => e.AuditAction)
                .HasColumnType("text")
                .HasColumnName("Audit_Action");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__State__5ED12EE253EF000E");

            entity.ToTable("State");

            entity.Property(e => e.StateId).HasColumnName("State Id");
            entity.Property(e => e.CountryId).HasColumnName("Country Id");
            entity.Property(e => e.StateName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("State Name");

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__State__Country I__412EB0B6");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07AFD1387C");

            entity.ToTable("Student");

            entity.Property(e => e.ImagePath)
                .IsUnicode(false)
                .HasColumnName("Image  Path");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Standard)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
