using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PopupStore.DAL.DB
{
    public partial class PopupStoreContext : DbContext
    {
        public PopupStoreContext()
        {
        }

        public PopupStoreContext(DbContextOptions<PopupStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sell> Sells { get; set; }
        public virtual DbSet<SellProductRel> SellProductRels { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PopupStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price");

                entity.HasIndex(e => e.Value, "IX_price")
                    .IsUnique();

                entity.HasIndex(e => e.Color, "IX_price_1")
                    .IsUnique();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(9);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.Label, "IX_product")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_product_1")
                    .IsUnique();

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_price");
            });

            modelBuilder.Entity<Sell>(entity =>
            {
                entity.ToTable("Sell");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<SellProductRel>(entity =>
            {
                entity.HasKey(e => new { e.SellId, e.ProductId });

                entity.ToTable("SellProductRel");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SellProductRels)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sell_product_rel_product");

                entity.HasOne(d => d.Sell)
                    .WithMany(p => p.SellProductRels)
                    .HasForeignKey(d => d.SellId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sell_product_rel_sell");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PeriodFrom).HasColumnType("date");

                entity.Property(e => e.PeriodTo).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
