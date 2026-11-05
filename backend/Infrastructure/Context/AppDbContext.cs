using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Artwork> Artworks { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<ArtImage> ArtImages { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Applies ImageConfiguration (and any others) automatically  
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }

}