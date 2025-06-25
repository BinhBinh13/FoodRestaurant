using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MenuFood_ConsoleApp.Models;

public partial class FoodRestaurantContext : DbContext
{
    public FoodRestaurantContext()
    {
    }

    public FoodRestaurantContext(DbContextOptions<FoodRestaurantContext> options)
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
        => optionsBuilder.UseSqlServer("Server=localhost;Database=FoodRestaurant;UId=sa;pwd=123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__Account__536C85E5B32882CB");

            entity.ToTable("Account");

            entity.Property(e => e.Username).HasMaxLength(100);
            entity.Property(e => e.Displayname).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bill__11F2FC4A9B95F386");

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
                .HasConstraintName("FK__Bill__TableID__59FA5E80");
        });

        modelBuilder.Entity<BillInfo>(entity =>
        {
            entity.HasKey(e => e.BillInfoId).HasName("PK__BillInfo__82266AC3AC269345");

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
            entity.HasKey(e => e.FoodId).HasName("PK__Food__856DB3CB0BC98D8E");

            entity.ToTable("Food");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.FoodName)
                .HasMaxLength(100)
                .HasDefaultValue("No name");
            entity.Property(e => e.Status).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Foods)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Food__CategoryId__5CD6CB2B");
        });

        modelBuilder.Entity<FoodCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__FoodCate__19093A2B1202EC21");

            entity.ToTable("FoodCategory");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasDefaultValue("No name");
        });

        modelBuilder.Entity<TableFood>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__TableFoo__7D5F018E6B4F02A6");

            entity.ToTable("TableFood");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasDefaultValue("Empty");
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .HasDefaultValue("No name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
