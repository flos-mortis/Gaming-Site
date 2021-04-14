using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNet.Identity.EntityFramework;

#nullable disable

namespace Playstore
{
    public partial class gaymNewsContext : DbContext
    {
        public gaymNewsContext()
        {
        }

        public gaymNewsContext(DbContextOptions<gaymNewsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<PlatformGame> PlatformGames { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=gaymNews;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Views).HasColumnName("views");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("article_user_id_fkey");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("cart_item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cart_item_game_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cart_item_user_id_fkey");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.UpvoteRating).HasColumnName("upvote_rating");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_game_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_user_id_fkey");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.DatePublished)
                    .HasColumnType("date")
                    .HasColumnName("date_published");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Image)
                    .HasColumnType("character varying")
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("publisher");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_genre_id_fkey");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.ToTable("platform");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PlatformGame>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("platform_game");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.PlatformId).HasColumnName("platform_id");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("platform_game_game_id_fkey");

                entity.HasOne(d => d.Platform)
                    .WithMany()
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("platform_game_platform_id_fkey");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.DatePublished)
                    .HasColumnType("date")
                    .HasColumnName("date_published");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("review_game_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("review_user_id_fkey");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("user_info");

                entity.HasIndex(e => e.Email, "user_info_email_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.About).HasColumnName("about");

                entity.Property(e => e.City)
                    .HasColumnType("character varying")
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasColumnType("character varying")
                    .HasColumnName("country");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasColumnName("date_created");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.FavGame).HasColumnName("fav_game");

                entity.Property(e => e.Gender)
                    .HasColumnType("character varying")
                    .HasColumnName("gender");

                entity.Property(e => e.Image)
                    .HasColumnType("character varying")
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("password_hash");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
