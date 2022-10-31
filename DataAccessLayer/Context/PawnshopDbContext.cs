using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context;

public class PawnshopDbContext : DbContext {

    public PawnshopDbContext(DbContextOptions options) : base(options) {
        
    }

    public DbSet<Pawnshop> Pawnshops { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Operation> Operations { get; set; }
    public DbSet<Make> Makes { get; set; }
    public DbSet<OperationType> OperationTypes { get; set; }
    public DbSet<WorkerPosition> WorkerPositions { get; set; }
    public DbSet<City> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Pawnshop>()
            .HasMany<Operation>()
            .WithOne()
            .HasForeignKey(o => o.PawnshopId);
        modelBuilder.Entity<Pawnshop>()
            .HasMany<Worker>()
            .WithOne()
            .HasForeignKey(w => w.PawnshopId);
        modelBuilder.Entity<Pawnshop>()
            .HasMany<Make>()
            .WithOne()
            .HasForeignKey(m => m.PawnshopId);
        modelBuilder.Entity<Pawnshop>()
            .HasOne<City>()
            .WithOne();


        modelBuilder.Entity<Worker>()
            .HasMany<Operation>()
            .WithOne()
            .HasForeignKey(o => o.WorkerId);
        modelBuilder.Entity<Worker>()
            .HasMany<Make>()
            .WithOne()
            .HasForeignKey(o => o.WorkerId);
        modelBuilder.Entity<Worker>()
            .HasMany<WorkerPosition>()
            .WithOne();


        modelBuilder.Entity<Operation>()
            .HasOne<OperationType>()
            .WithOne();
        
        
        modelBuilder.Entity<Customer>()
            .HasMany<Operation>()
            .WithOne()
            .HasForeignKey(o => o.CustomerId);
        modelBuilder.Entity<Customer>()
            .HasMany<Make>()
            .WithOne()
            .HasForeignKey(o => o.CustomerId);
    }
}