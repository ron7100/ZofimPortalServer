using System;
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

        public virtual DbSet<ActivitiesHistory> ActivitiesHistories { get; set; }
        public virtual DbSet<Cadet> Cadets { get; set; }
        public virtual DbSet<CadetParent> CadetParents { get; set; }
        public virtual DbSet<Hanhaga> Hanhagas { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shevet> Shevets { get; set; }
        public virtual DbSet<User> Users { get; set; }
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

            modelBuilder.Entity<ActivitiesHistory>(entity =>
            {
                entity.HasKey(e => new { e.CadetId, e.Activity });

                entity.ToTable("ActivitiesHistory");

                entity.Property(e => e.CadetId).HasColumnName("CadetID");

                entity.Property(e => e.Activity).HasMaxLength(50);

                entity.HasOne(d => d.Cadet)
                    .WithMany(p => p.ActivitiesHistories)
                    .HasForeignKey(d => d.CadetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivitiesHistory_Cadet");
            });

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

                entity.Property(e => e.PersonalId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PersonalID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.ShevetId).HasColumnName("ShevetID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Cadets)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadet_Role");

                entity.HasOne(d => d.Shevet)
                    .WithMany(p => p.Cadets)
                    .HasForeignKey(d => d.ShevetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadet_Shevet");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cadets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadet_User");
            });

            modelBuilder.Entity<CadetParent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Cadet_Parent");

                entity.Property(e => e.CadetId).HasColumnName("CadetID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Cadet)
                    .WithMany()
                    .HasForeignKey(d => d.CadetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadet_Parent_Cadet");

                entity.HasOne(d => d.Parent)
                    .WithMany()
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadet_Parent_Parent");
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

                entity.Property(e => e.PersonalId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("personalID");

                entity.Property(e => e.ShevetId).HasColumnName("ShevetID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Shevet)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.ShevetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parent_Shevet");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parent_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
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

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");
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

                entity.Property(e => e.PersonalId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PersonalID");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShevetId).HasColumnName("ShevetID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Hanhaga)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.HanhagaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_Hanhaga");

                entity.HasOne(d => d.Shevet)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.ShevetId)
                    .HasConstraintName("FK_Worker_Shevet");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
