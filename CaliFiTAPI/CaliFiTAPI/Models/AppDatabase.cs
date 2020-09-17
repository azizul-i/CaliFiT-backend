using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaliFiTAPI.Models
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options): base(options) 
        {
            
        }

        public DbSet<User> User { get; set; }

        public DbSet<Workout> Workout { get; set; }

        public DbSet<Excercise> Excercise { get; set; }

        public DbSet<Completed> Completed { get; set; }

        //public static System.Collections.Specialized.NameValueCollection AppSettings { get; }

        //// configure the database to be used by this context
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //   .AddJsonFile("appsettings.json")
        //   .Build();

        //    // schoolSIMSConnection is the name of the key that
        //    // contains the has the connection string as the value
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("sqlDatabase"));
        //}
    }
}
