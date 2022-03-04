using HerokuAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HerokuAPI.Services;

public sealed class ApplicationContext: DbContext
{
    public DbSet<User> Users { get; set; } 
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = GetConnectionString();
        optionsBuilder.UseNpgsql(connectionString);
    }
    private static string GetConnectionString()
    {
        //return "Host=localhost;Username=postgres;Password=password;Database=HEROKUtest";
        
        
        var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        connUrl = connUrl!.Replace("postgres://", string.Empty);
        var pgUserPass = connUrl.Split("@")[0];
        var pgHostPortDb = connUrl.Split("@")[1];
        var pgHostPort = pgHostPortDb.Split("/")[0];
            
        var pgDb = pgHostPortDb.Split("/")[1];
        var pgUser = pgUserPass.Split(":")[0];
        var pgPass = pgUserPass.Split(":")[1];
        var pgHost = pgHostPort.Split(":")[0];
        var pgPort = pgHostPort.Split(":")[1];
            
        return $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb}";
    }
}