using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database
{
    public class RegionContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.UseSqlite("Data Source=region.db");
        }
    }
}
