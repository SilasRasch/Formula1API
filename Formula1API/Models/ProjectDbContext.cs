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
            var connectionString = AuthConstants.GetConnectionString(false, _config);

            var serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion);

            // Local / Portainer DB
            //var connectionString = AuthConstants.GetConnectionString(true, _config);
            //optionsBuilder.UseSqlServer(connectionString);
        }
    }
}