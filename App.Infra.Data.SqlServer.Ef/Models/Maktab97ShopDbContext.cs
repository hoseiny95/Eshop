using System;
using System.Collections.Generic;
using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.SqlServer.Ef.Models;

public partial class Maktab97ShopDbContext : IdentityDbContext<ApplicationUser,IdentityRole<int>,int>
{
    public Maktab97ShopDbContext()
    {
    }

    public Maktab97ShopDbContext(DbContextOptions<Maktab97ShopDbContext> options)
        : base(options)
    {
    }
    public DbSet<ApplicationUser> Users { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CustomAttributeTemplate> CustomAttributeTemplates { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCustomAttribute> ProductCustomAttributes { get; set; }

    public virtual DbSet<ProductInventory> ProductInventories { get; set; }

    public virtual DbSet<ProductPrice> ProductPrices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Maktab97_ShopDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<CustomAttributeTemplate>(entity =>
        {
            entity.Property(e => e.AttributeTitle).HasMaxLength(250);

            entity.HasOne(d => d.Category).WithMany(p => p.CustomAttributeTemplates)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomAttributeTemplates_Categories");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderAt).HasColumnType("datetime");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_OrderStatuses");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderLines_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderLines_Products");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<ProductCustomAttribute>(entity =>
        {
            entity.Property(e => e.AttributeTitle).HasMaxLength(250);
            entity.Property(e => e.AttributeValue).HasMaxLength(250);

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductCustomAttributes)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCustomAttributes_CustomAttributeTemplates");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCustomAttributes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCustomAttributes_Products");
        });

        modelBuilder.Entity<ProductInventory>(entity =>
        {
            entity.ToTable("ProductInventory");

            entity.Property(e => e.ActionAt).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductInventories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductInventory_Products");
        });

        modelBuilder.Entity<ProductPrice>(entity =>
        {
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.ToDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPrices)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductPrices_Products");
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
