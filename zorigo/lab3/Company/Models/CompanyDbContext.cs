using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Company.Models;

public partial class CompanyDbContext : DbContext
{
    public CompanyDbContext()
    {
    }

    public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=CompanyDB;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.Branchid).HasName("branches_pkey");

            entity.ToTable("branches");

            entity.Property(e => e.Branchid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("branchid");
            entity.Property(e => e.Branchname)
                .HasMaxLength(100)
                .HasColumnName("branchname");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Workerid).HasName("workers_pkey");

            entity.ToTable("workers");

            entity.Property(e => e.Workerid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("workerid");
            entity.Property(e => e.Branchid).HasColumnName("branchid");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");

            entity.HasOne(d => d.Branch).WithMany(p => p.Workers)
                .HasForeignKey(d => d.Branchid)
                .HasConstraintName("fk_branch");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
