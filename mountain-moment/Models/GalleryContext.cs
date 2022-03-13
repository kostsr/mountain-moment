using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mountain_moment.Models
{
    public class GalleryContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public GalleryContext(DbContextOptions<GalleryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
