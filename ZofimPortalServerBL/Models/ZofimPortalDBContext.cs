﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    public partial class ZofimPortalDBContext : DbContext
    {
        public ZofimPortalDBContext()
        {
        }

        public ZofimPortalDBContext(DbContextOptions<ZofimPortalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cadet> Cadets { get; set; }
        public virtual DbSet<Hanhaga> Hanhagas { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Shevet> Shevets { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=ZofimPortalDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Cadet>(entity =>
            {
                entity.ToTable("Cadet");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lName");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pass");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShevetId).HasColumnName("ShevetID");

                entity.Property(e => e.UName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("uName");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Cadets)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadet_Parent");

                entity.HasOne(d => d.Shevet)
                    .WithMany(p => p.Cadets)
                    .HasForeignKey(d => d.ShevetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadet_Shevet");
            });

            modelBuilder.Entity<Hanhaga>(entity =>
            {
                entity.ToTable("Hanhaga");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.GeneralArea)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("Parent");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lName");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pass");

                entity.Property(e => e.PersonalId).HasColumnName("personalID");

                entity.Property(e => e.ShevetId).HasColumnName("ShevetID");

                entity.Property(e => e.UName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("uName");

                entity.HasOne(d => d.Shevet)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.ShevetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parent_Shevet");
            });

            modelBuilder.Entity<Shevet>(entity =>
            {
                entity.ToTable("Shevet");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.HanhagaId).HasColumnName("HanhagaID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Hanhaga)
                    .WithMany(p => p.Shevets)
                    .HasForeignKey(d => d.HanhagaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shevet_Hanhaga");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("Worker");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.HanhagaId).HasColumnName("HanhagaID");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lName");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pass");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShevetId).HasColumnName("ShevetID");

                entity.Property(e => e.UName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("uName");

                entity.HasOne(d => d.Hanhaga)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.HanhagaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_Hanhaga");

                entity.HasOne(d => d.Shevet)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.ShevetId)
                    .HasConstraintName("FK_Worker_Shevet");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
