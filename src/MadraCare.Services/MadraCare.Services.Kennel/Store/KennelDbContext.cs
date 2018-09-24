using Microsoft.EntityFrameworkCore;
using MadraCare.Models;

namespace MadraCare.Services.Kennel.Store
{

    public partial class KennelDbContext : DbContext
    {
        public KennelDbContext()
        { }

        public KennelDbContext(DbContextOptions<KennelDbContext> options) : base(options)
        { }

        public virtual DbSet<Models.Kennel> Kennels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}