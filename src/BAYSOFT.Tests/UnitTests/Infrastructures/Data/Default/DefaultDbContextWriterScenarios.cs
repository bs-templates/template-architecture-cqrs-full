using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Entity;
using BAYSOFT.Tests.Helpers.Data.DefaultDb;
using BAYSOFT.Tests.Helpers.Data.DefaultDb.Samples;

namespace BAYSOFT.Tests.UnitTests.Infrastructures.Data.Default
{
	[TestClass]
	public class DefaultDbContextWriterScenarios
	{
		[TestMethod]
		public void DefaultDbContextReader_Add_Should_Not_Throw_Exception()
		{
			using (var context = DefaultDbContextExtensions.GetInMemoryDefaultDbContext().SetupSamples())
			{
				var defaultDbContextReader = context.GetDbContextReader();
				var defaultDbContextWriter = context.GetDbContextWriter();

				var entity = new Sample { Description = "new sample" };

				defaultDbContextWriter.Add(entity);
				context.SaveChanges();

				Assert.IsTrue(defaultDbContextReader.Query<Sample>().Any(x => x.Description == entity.Description));
				Assert.IsTrue(entity.Id != SamplesCollections.FromInt(0));
			}
		}
	}
}
