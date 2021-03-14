using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using codiling.Models;

#nullable disable

namespace codiling.Contexts
{
    public partial class codilingContext : DbContext
    {
        public codilingContext()
        {
        }

        public codilingContext(DbContextOptions<codilingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CodingChallenge> CodingChallenges { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Submission> Submissions { get; set; }
        public virtual DbSet<SubmissionResult> SubmissionResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=codiling;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CodingChallenge>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdCodingChallenges).HasColumnName("ID_CodingChallenges");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Solution).IsRequired();

                entity.HasOne(d => d.IdCodingChallengesNavigation)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.IdCodingChallenges)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Submissions_CodingChallenges");
            });

            modelBuilder.Entity<SubmissionResult>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Tasks).IsRequired();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
