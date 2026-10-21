namespace WebApplication3.Data;

using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Teacher> Teachers { get; set; }
}