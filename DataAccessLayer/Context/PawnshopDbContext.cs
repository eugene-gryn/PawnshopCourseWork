using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context;

#nullable disable

public class PawnshopDbContext : DbContext {
    public PawnshopDbContext(DbContextOptions options) : base(options) { }

    public PawnshopDbContext() { }

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
            .WithOne(o => o.Pawnshop)
            .HasForeignKey(o => o.PawnshopId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Pawnshop>()
            .HasMany<Worker>()
            .WithOne(w => w.Pawnshop)
            .HasForeignKey(w => w.PawnshopId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Pawnshop>()
            .HasMany<Make>()
            .WithOne(m => m.Pawnshop)
            .HasForeignKey(m => m.PawnshopId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<City>()
            .HasMany<Pawnshop>()
            .WithOne(p => p.City)
            .HasForeignKey(p => p.CityId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Worker>()
            .HasMany<Operation>()
            .WithOne(o => o.Worker)
            .HasForeignKey(o => o.WorkerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<Worker>()
            .HasMany<Make>()
            .WithOne(m => m.Worker)
            .HasForeignKey(o => o.WorkerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<WorkerPosition>()
            .HasMany<Worker>()
            .WithOne(w => w.Position)
            .HasForeignKey(w => w.PositionId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<OperationType>()
            .HasMany<Operation>()
            .WithOne(o => o.OperationType)
            .HasForeignKey(o => o.OperationTypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Customer>()
            .HasMany<Operation>()
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<Customer>()
            .HasMany<Make>()
            .WithOne(m => m.Customer)
            .HasForeignKey(o => o.CustomerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientSetNull);
        // Check in Db that Customer older than 18 years
        modelBuilder.Entity<Customer>()
            .HasCheckConstraint("CHK_DateIsGrater18", "(DATEDIFF(year, Birthday, GETDATE()) > 17)");

    }
}