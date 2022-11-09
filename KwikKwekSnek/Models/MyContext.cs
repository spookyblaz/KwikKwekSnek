using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KwikKwekSnek.Models;

namespace KwikKwekSnek.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json")
         .Build();

        public MyContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<MyContext>();
            builder.UseSqlServer(Configuration.GetConnectionString("FirstAndSecond"));

            return new MyContext(builder.Options);
        }
        public DbSet<KwikKwekSnek.Models.Drankje> drankjes { get; set; }
        public DbSet<KwikKwekSnek.Models.Bestelling> Bestelling { get; set; }
    }
}
