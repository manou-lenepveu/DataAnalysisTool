using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base (opts) {
    }

    public DbSet<Flower> Flowers => Set<Flower>();
}