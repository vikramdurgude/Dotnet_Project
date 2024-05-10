using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPWebAPICRUD.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Fathername)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("fathername");
            entity.Property(e => e.Standard).HasColumnName("standard");
            entity.Property(e => e.Studentgender)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("studentgender");
            entity.Property(e => e.Studentname)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("studentname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
