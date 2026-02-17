using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Entity;
using BAYSOFT.Infrastructures.Data.DefaultDb;
using BAYSOFT.Tests.Helpers.Data.DefaultDb.Samples;

namespace BAYSOFT.Tests.Helpers.Data.DefaultDb
{
	internal static class AddMockedSamplesExtensions
	{
		public static DefaultDbContext SetupSamples(this DefaultDbContext context, List<Sample>? entities = null)
		{
			if (entities == null)
			{
				entities = SamplesCollections.GetDefaultCollection();
			}

			context.AddRange(entities);
			context.SaveChanges();

			return context;
		}
	}
}
