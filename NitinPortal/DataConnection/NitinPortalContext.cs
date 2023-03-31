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

    public virtual DbSet<Images> Images { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-94NN4I6;Initial Catalog=NitinPortal;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Images>(entity =>
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
