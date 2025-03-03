using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Config
{
    public class InvDbContext : DbContext
    {
        public InvDbContext(DbContextOptions<InvDbContext> options)
            : base(options)
        { }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Organization: 1 Organization to many Stores
            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Name)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.HasMany(o => o.Stores)
                      .WithOne(s => s.Organization)
                      .HasForeignKey(s => s.OrganizationId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                // Configurar el enum Position para almacenarlo como string
                entity.Property(u => u.Position)
                      .HasConversion<string>()
                      .HasMaxLength(50)
                      .IsRequired();

                // Si deseas que el usuario tenga una colección de historiales:
                entity.HasMany(u => u.ProductHistories)
                      .WithOne(ph => ph.User)
                      .HasForeignKey(ph => ph.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Store: each store has one Warehouse
            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name)
                      .HasMaxLength(200)
                      .IsRequired();
                entity.Property(s => s.Address)
                      .HasMaxLength(300);

                // Relación 1:1 entre Store y Warehouse (Warehouse es dependiente)
                entity.HasOne(s => s.Warehouse)
                      .WithOne(w => w.Store)
                      .HasForeignKey<Warehouse>(w => w.StoreId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Warehouse
            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(w => w.Id);
                entity.Property(w => w.Location)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.HasMany(w => w.InventoryItems)
                      .WithOne(ii => ii.Warehouse)
                      .HasForeignKey(ii => ii.WarehouseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name)
                      .HasMaxLength(200)
                      .IsRequired();
                entity.Property(p => p.Price)
                      .HasColumnType("decimal(18,2)");
            });

            // InventoryItem
            modelBuilder.Entity<InventoryItem>(entity =>
            {
                entity.HasKey(ii => ii.Id);

                entity.HasOne(ii => ii.Product)
                      .WithMany(p => p.InventoryItems)
                      .HasForeignKey(ii => ii.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Sale: each sale belongs to a store and has one invoice
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Total)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(s => s.Store)
                      .WithMany() // Opcional: si agregas ICollection<Sale> en Store
                      .HasForeignKey(s => s.StoreId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Invoice)
                      .WithOne(i => i.Sale)
                      .HasForeignKey<Invoice>(i => i.SaleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Invoice
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Details)
                      .HasMaxLength(500);
            });

            // ProductHistory
            modelBuilder.Entity<ProductHistory>(entity =>
            {
                entity.HasKey(ph => ph.Id);
                entity.Property(ph => ph.Action)
                      .HasConversion<string>()  // Almacena el enum como string
                      .HasMaxLength(50)
                      .IsRequired();
                entity.Property(ph => ph.ChangedBy)
                      .HasMaxLength(100);

                entity.HasOne(ph => ph.Product)
                      .WithMany(p => p.ProductHistories)
                      .HasForeignKey(ph => ph.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relación con User (ya configurada en User, pero se define aquí también para mayor claridad)
                entity.HasOne(ph => ph.User)
                      .WithMany(u => u.ProductHistories)
                      .HasForeignKey(ph => ph.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
