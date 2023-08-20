using Microsoft.EntityFrameworkCore;
using ShareRider2.Models;

namespace ShareRider2.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Journey> Journeys { get; set; }
    public DbSet<ShareRider> ShareRiders { get; set; }
    public DbSet<City> Cities { get; set; }
}