using Microsoft.EntityFrameworkCore;

namespace Formula1API.Models
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; } 
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=mysql118.unoeuro.com;user=voresdomaene_dk;password=RD6dag4pnmbyBekGErft;database=voresdomaene_dk_db_formula1";
            var serverVersion = new MySqlServerVersion(new Version(8, 2));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
