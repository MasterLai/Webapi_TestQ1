using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;

namespace Infrastructure;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=test;User Id=sa;Password=P@ssw0rd;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Serial);

            entity.ToTable("test");

            entity.Property(e => e.Serial).HasColumnName("serial");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Associationtype)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("associationtype");
            entity.Property(e => e.Branchtype)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("branchtype");
            entity.Property(e => e.County)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("county");
            entity.Property(e => e.Financialcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("financialcode");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("postalcode");
            entity.Property(e => e.Telepon)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("telepon");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
