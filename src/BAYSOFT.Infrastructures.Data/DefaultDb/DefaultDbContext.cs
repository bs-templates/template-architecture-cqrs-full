
using BAYSOFT.Abstractions.Core.Domain.Interfaces.Infrastructures.Data;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Entity;
using BAYSOFT.Infrastructures.Data.DefaultDb.EntityMappings;
using Microsoft.EntityFrameworkCore;

namespace BAYSOFT.Infrastructures.Data.DefaultDb
{
    public sealed class DefaultDbContext : DbContext
    {
        public static string Schema => "DefaultDb";

        public DbSet<Sample> Samples { get; set; }
        public DefaultDbContext() { }
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options){ }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.ApplyConfiguration(new SampleMap());
        }
    }
}