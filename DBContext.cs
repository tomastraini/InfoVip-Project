using System.Collections.Generic;
using System.Reflection.Emit;
using System.Transactions;
using System;
using Microsoft.EntityFrameworkCore;
using InfoVip.Models;
using InfoVip.Models.Configurations;

namespace InfoVip
{
    public partial class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public IConfigurationRoot Configuration { get; }
        public DBContext()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public DbSet<ApiKey> apiKeys { get; set; }
        public DbSet<apiportfolioIDs> apiportfolioIDs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ApiKeyConfiguration());
            modelBuilder.ApplyConfiguration(new apiportfolioIDsConfiguration());



            OnModelCreatingPartial(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DB"));
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
