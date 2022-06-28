
using Microsoft.EntityFrameworkCore;

namespace XMen.Api.DAL
{
    public class MutantContext : DbContext
    {
        public MutantContext(DbContextOptions<MutantContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mutant>().HasKey( c => c.ADN);
        }
        public DbSet<Mutant> Mutants { get; set; }

        public class Mutant
        {
            public bool IsMutant { get; set; }
            public string ADN { get; set; }
        }
    }
}
