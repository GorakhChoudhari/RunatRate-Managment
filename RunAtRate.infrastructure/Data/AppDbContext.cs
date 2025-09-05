
using RunAtRate.Appllication.DTOs;

namespace RunAtRate.infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<InspectionDto> Inspections { get; set; } = null!;
    public DbSet<Country> Countries { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Employee> Employees { get; set; }

    // Product & Inventory
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Inventory> Inventories { get; set; }

    // Sales & Orders
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Payment> Payments { get; set; }

    // Production & Quality
    public DbSet<ProductionBatch> ProductionBatches { get; set; }
    public DbSet<QualityChecks> QualityChecks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ================================
        // Employee self reference
        // ================================
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Manager);
            //.WithMany(e => e.Subordinates)
            //.HasForeignKey(e => e.ManagerID)
            //.OnDelete(DeleteBehavior.Restrict);

        // ================================
        // Product unique constraint
        // ================================
        modelBuilder.Entity<Product>()
            .HasIndex(p => new { p.ProductName, p.SupplierID })
            .IsUnique();

        // ================================
        // Inventory unique constraint
        // ================================
        modelBuilder.Entity<Inventory>()
            .HasIndex(i => new { i.ProductID, i.WarehouseID })
            .IsUnique();

        // ================================
        // OrderDetail unique constraint
        // ================================
        modelBuilder.Entity<OrderDetail>()
            .HasIndex(od => new { od.OrderID, od.ProductID })
            .IsUnique();

        // ================================
        // Payment validation
        // ================================
        modelBuilder.Entity<Payment>()
            .Property(p => p.PaymentMethod)
            .HasConversion<string>(); // store as string (Cash, Card, UPI, NetBanking)

        // ================================
        // Indexes from script
        // ================================
        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.CountryID);

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.CategoryID);

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(o => o.OrderID); // PK

            entity.Property(o => o.Status)
                  .HasMaxLength(50)
                  .HasDefaultValue("Pending");

            entity.Property(o => o.OrderDate)
                  .HasDefaultValueSql("GETDATE()");

            // Relationships
            entity.HasOne(o => o.Customer)
                  .WithMany(c => c.Orders)
                  .HasForeignKey(o => o.CustomerID);

            entity.HasMany(o => o.OrderDetails)
                  .WithOne(od => od.Order)
                  .HasForeignKey(od => od.OrderID);

            entity.HasMany(o => o.Payments)
                  .WithOne(p => p.Order)
                  .HasForeignKey(p => p.OrderID);
        });


        modelBuilder.Entity<OrderDetail>()
            .HasIndex(od => od.OrderID);

        modelBuilder.Entity<Inventory>()
            .HasIndex(i => i.ProductID);

        modelBuilder.Entity<Payment>()
            .HasIndex(p => p.OrderID);
        modelBuilder.Entity<ProductionBatch>(entity =>
        {
            entity.HasKey(o => o.BatchID);
        });
        modelBuilder.Entity<QualityChecks>(entity =>
        {
            entity.HasKey(o => o.QCID);
        });
    }
}

