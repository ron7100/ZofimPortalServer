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
        public virtual DbSet<Activity> Activities { get; set; }
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
                optionsBuilder.UseSqlServer("Server=DESKTOP-J4KA0BE\\SQLEXPRESS; Database=ZofimPortalDB; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<ActivitiesHistory>(entity =>
            {
                entity.HasKey(e => new { e.CadetId, e.ActivityId });

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivitiesHistories)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivitiesHistory_Activity");

                entity.HasOne(d => d.Cadet)
                    .WithMany(p => p.ActivitiesHistories)
                    .HasForeignKey(d => d.CadetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivitiesHistory_Cadet");
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Hanhaga)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.HanhagaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Hanhaga");

                entity.HasOne(d => d.Shevet)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ShevetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Shevet");
            });

            modelBuilder.Entity<Cadet>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

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
            });

            modelBuilder.Entity<CadetParent>(entity =>
            {
                entity.HasKey(e => new { e.ParentId, e.CadetId });

                entity.HasOne(d => d.Cadet)
                    .WithMany(p => p.CadetParents)
                    .HasForeignKey(d => d.CadetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadet_Parent_Cadet");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.CadetParents)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadet_Parent_Parent");
            });

            modelBuilder.Entity<Hanhaga>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Shevet)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.ShevetId)
                    .HasConstraintName("FK_Parent_Shevet");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parent_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Shevet>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Hanhaga)
                    .WithMany(p => p.Shevets)
                    .HasForeignKey(d => d.HanhagaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shevet_Hanhaga");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Hanhaga)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.HanhagaId)
                    .HasConstraintName("FK_Worker_Hanhaga");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_Role");

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
