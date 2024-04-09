using Formula1API.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Formula1API.Models
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        #region Local host constructor
        private IConfiguration _config;

        public ProjectDbContext(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = AuthConstants.GetConnectionString(_config);

            var serverVersion = new MySqlServerVersion(new Version(8, 2));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}