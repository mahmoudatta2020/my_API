using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace my_API.Models
{
    public partial class mahmoudAPIContext : DbContext
    {
        public mahmoudAPIContext(DbContextOptions<mahmoudAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books1> Books1 { get; set; }
        public virtual DbSet<UserInfo1> UserInfo1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books1>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__Books1__8BE5A10DC2737818");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.Auther)
                    .HasColumnName("auther")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BookPrice)
                    .HasColumnName("bookPrice")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<UserInfo1>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__userInfo__CB9A1CFF65E4366A");

                entity.ToTable("userInfo1");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnName("createDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
