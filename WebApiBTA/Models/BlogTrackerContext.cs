using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiBTA.Models;

public partial class BlogTrackerContext : DbContext
{
    public BlogTrackerContext()
    {
    }

    public BlogTrackerContext(DbContextOptions<BlogTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminInfo> AdminInfos { get; set; }

    public virtual DbSet<BlogInfo> BlogInfos { get; set; }

    public virtual DbSet<EmpInfo> EmpInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=tcp:raven22.database.windows.net,1433;Initial Catalog=BlogTracker;Persist Security Info=False;User ID=Raven22;Password=localhost:8080;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminInf__3214EC07D56BDA03");

            entity.ToTable("AdminInfo");

            entity.Property(e => e.EmailId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BlogInfo>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__BlogInfo__54379E301FF73C15");

            entity.ToTable("BlogInfo");

            entity.Property(e => e.BlogUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateOfCreation).HasColumnType("datetime");
            entity.Property(e => e.EmpEmailId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmpInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EmpInfo__3214EC074FCE8539");

            entity.ToTable("EmpInfo");

            entity.HasIndex(e => e.EmailId, "UQ__EmpInfo__7ED91ACE5DA76DEC").IsUnique();

            entity.Property(e => e.DateOfJoining).HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
