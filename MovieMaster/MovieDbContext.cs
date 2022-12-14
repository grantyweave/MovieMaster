using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMaster
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        
        private static IConfigurationRoot _configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
            string cnstr = _configuration.GetConnectionString("MovieMaster");
            optionsBuilder.UseSqlServer(cnstr);
        }
    }
    }
    

}
