using Microsoft.EntityFrameworkCore;

namespace PRDSDS.API.Data;

public class AppDbContext: DbContext
{
    private readonly IConfiguration _configuration;
    
    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        Database.Migrate();
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("AppDB"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>()
            .HasKey(x => x.ID);
    }
}
