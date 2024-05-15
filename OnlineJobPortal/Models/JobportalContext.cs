using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineJobPortal.Models;

public partial class JobportalContext : DbContext
{
    public JobportalContext()
    {
    }

    public JobportalContext(DbContextOptions<JobportalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<JobList> JobLists { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<ViewResume> ViewResumes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<JobList>(entity =>
        {
            entity.HasKey(e => e.JobTitle).HasName("PRIMARY");

            entity.ToTable("job list");

            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .HasColumnName("Job Title");
            entity.Property(e => e.Company).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.ExperienceReqiured)
                .HasColumnType("int(11)")
                .HasColumnName("Experience Reqiured");
            entity.Property(e => e.NoOfPost)
                .HasColumnType("int(11)")
                .HasColumnName("No. of Post");
            entity.Property(e => e.QualificationReqiured)
                .HasMaxLength(50)
                .HasColumnName("Qualification Reqiured");
            entity.Property(e => e.State).HasMaxLength(50);
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("login");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<ViewResume>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("view resume");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .HasColumnName("Company Name");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .HasColumnName("Job Title");
            entity.Property(e => e.MobileNo)
                .HasColumnType("bigint(10)")
                .HasColumnName("Mobile No.");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .HasColumnName("User Email");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("User Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
