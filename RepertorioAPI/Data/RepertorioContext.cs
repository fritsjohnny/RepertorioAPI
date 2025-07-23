using Microsoft.EntityFrameworkCore;
using RepertorioAPI.Models;

namespace RepertorioAPI.Data
{
    public partial class RepertorioContext : DbContext
    {
        public RepertorioContext()
        {
        }

        public RepertorioContext(DbContextOptions<RepertorioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Repertoire> Repertoires { get; set; }
        public virtual DbSet<RepertoireSong> RepertoireSongs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Repertoire
            modelBuilder.Entity<Repertoire>(entity =>
            {
                entity.ToTable("Repertoires", "Repertorio");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).HasMaxLength(100);
                entity.Property(e => e.ServiceDate);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            });

            // Song
            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Songs", "Repertorio");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).HasMaxLength(200);
                entity.Property(e => e.Artist).HasMaxLength(100);
                entity.Property(e => e.Theme).HasMaxLength(50);
                entity.Property(e => e.Tags).HasMaxLength(200);
                entity.Property(e => e.BibleReferences).HasMaxLength(300);
                entity.Property(e => e.ExternalLink).HasMaxLength(300);
                entity.Property(e => e.Key).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.Tempo).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.WorshipType).HasMaxLength(20).HasDefaultValue("Adoração");
            });

            // RepertoireSong
            modelBuilder.Entity<RepertoireSong>(entity =>
            {
                entity.ToTable("RepertoireSongs", "Repertorio");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Minister).HasMaxLength(100).HasDefaultValue("");
                entity.HasOne(d => d.Repertoire)
                    .WithMany(p => p.RepertoireSongs)
                    .HasForeignKey(d => d.RepertoireId);
                entity.HasOne(d => d.Song)
                    .WithMany(p => p.RepertoireSongs)
                    .HasForeignKey(d => d.SongId);
            });

            // User (Repertorio schema)
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "Repertorio");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Username).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.PasswordHash).HasMaxLength(255);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
