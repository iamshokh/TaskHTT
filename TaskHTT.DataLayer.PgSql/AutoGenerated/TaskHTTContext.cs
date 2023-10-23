using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskHTT.DataLayer.PgSql
{
    public partial class TaskHTTContext : DbContext
    {
        public TaskHTTContext()
        {
        }

        public TaskHTTContext(DbContextOptions<TaskHTTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EnumCategory> EnumCategories { get; set; } = null!;
        public virtual DbSet<EnumProduct> EnumProducts { get; set; } = null!;
        public virtual DbSet<EnumState> EnumStates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=shaxzod71319#;Database=TaskHTT");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnumCategory>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.EnumCategories)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<EnumProduct>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.EnumProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_category_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.EnumProducts)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<EnumState>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
