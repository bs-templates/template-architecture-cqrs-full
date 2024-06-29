using Microsoft.EntityFrameworkCore;

namespace BAYSOFT.Infrastructures.Data.Identity
{
	public class IdentityDbContext : DbContext
	{
		protected IdentityDbContext()
		{
			if (Database.IsRelational())
			{
				Database.Migrate();
			}
		}
		public IdentityDbContext(DbContextOptions options) : base(options)
		{
			if (Database.IsRelational())
			{
				Database.Migrate();
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("IdentityDb");
		}
	}
}
