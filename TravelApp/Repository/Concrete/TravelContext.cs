using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;

namespace TravelApp.Repository.Concrete
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            :base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Otel> Otels { get; set; }
        public DbSet<Sehir> Sehirs { get; set; }
        public DbSet<Lokanta> Lokantas { get; set; }
        public DbSet<Soru> Sorus { get; set; }
    }
}
