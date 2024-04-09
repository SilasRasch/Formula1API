using Formula1API.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Formula1API.Models
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        private string _connectionString;

        #region Local host constructor
        private IConfiguration _config;

        public ProjectDbContext(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Portainer / Azure
            var env = Environment.GetEnvironmentVariable(AuthConstants.SimplyConnectionString)!; // Simply
            //var env = Environment.GetEnvironmentVariable(AuthConstants.LocalConnectionString!); // Local

            // Local
            var appsetting = _config.GetValue<string>(AuthConstants.SimplyConnectionString)!;

            // Check if local or environment
            if (env != null)
            {
                _connectionString = env;
            }
            else
            {
                _connectionString = appsetting;
            }

            var serverVersion = new MySqlServerVersion(new Version(8, 2));
            optionsBuilder.UseMySql(_connectionString, serverVersion);
        }
    }
}