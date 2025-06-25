using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodRestaurant.Models;

public partial class CafeRestaurantContext : DbContext
{
    public CafeRestaurantContext()
    {
    }

    public CafeRestaurantContext(DbContextOptions<CafeRestaurantContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillInfo> BillInfos { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodCategory> FoodCategories { get; set; }

    public virtual DbSet<TableFood> TableFoods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=CafeRestaurant;UId=sa;pwd=123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__Account__536C85E532D25B65");

            entity.ToTable("Account");

            entity.Property(e => e.Username).HasMaxLength(100);
            entity.Property(e => e.Displayname).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bill__11F2FC4ADAF8E742");

            entity.ToTable("Bill");

            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.DateCheckIn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateCheckOut).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.TableId).HasColumnName("TableID");

            entity.HasOne(d => d.Table).WithMany(p => p.Bills)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bill__TableID__5812160E");
        });

        modelBuilder.Entity<BillInfo>(entity =>
        {
            entity.HasKey(e => e.BillInfoId).HasName("PK__BillInfo__82266AC3878FF8F1");

            entity.ToTable("BillInfo");

            entity.Property(e => e.BillInfoId).HasColumnName("BillInfoID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.FoodId).HasColumnName("FoodID");

            entity.HasOne(d => d.Bill).WithMany(p => p.BillInfos)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillInfo__BillID__5AEE82B9");

            entity.HasOne(d => d.Food).WithMany(p => p.BillInfos)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillInfo__FoodID__5BE2A6F2");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__Food__856DB3CBA97A4C29");

            entity.ToTable("Food");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.FoodName)
                .HasMaxLength(100)
                .HasDefaultValue("Chưa đặt tên");
            entity.Property(e => e.Status).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Foods)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Food__CategoryId__5070F446");
        });

        modelBuilder.Entity<FoodCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__FoodCate__19093A2BC4294895");

            entity.ToTable("FoodCategory");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasDefaultValue("Chưa đặt tên");
        });

        modelBuilder.Entity<TableFood>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__TableFoo__7D5F018E1B87EA58");

            entity.ToTable("TableFood");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasDefaultValue("Trống");
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .HasDefaultValue("Chưa đặt tên");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
