﻿using Formula1API.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Formula1API.Models
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable(AuthConstants.AzureDbConnectionString)!;
            var serverVersion = new MySqlServerVersion(new Version(8, 2));

            optionsBuilder.UseMySql(connectionString, serverVersion);

            // Local DB
            //string localConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=F1Local;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //optionsBuilder.UseSqlServer(localConnectionString);
        }
    }
}