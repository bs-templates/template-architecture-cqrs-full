using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Entity;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Services;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Validations.DomainValidations;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Validations;
using BAYSOFT.Infrastructures.Data.DefaultDb;
using BAYSOFT.Tests.Helpers;
using BAYSOFT.Tests.Helpers.Data.DefaultDb;
using BAYSOFT.Tests.Helpers.Data.DefaultDb.Samples;

namespace BAYSOFT.Tests.UnitTests.Core.Domain.DefaultDb.Entities.Samples.Services
{
	[TestClass]
	public class DeleteSampleServiceScenarios
	{
		[TestMethod]
		public async Task DELETE_Sample_Should_Not_Return_Exception()
		{
			var contextData = SamplesCollections.GetDefaultCollection();

			using (var context = DefaultDbContextExtensions.GetInMemoryDefaultDbContext().SetupSamples(contextData))
			{
				var reader = new DefaultDbContextReader(context);
				var writer = new DefaultDbContextWriter(context);

				var localizer = GenericHelper.CreateLocalizer<Sample>();

				var validator = new SampleValidator();

				var specificationsValidator = new DeleteSampleSpecificationsValidator();

				var handler = new DeleteSampleServiceRequestHandler(writer, localizer, validator, specificationsValidator);

				var sample = contextData.First();

				var request = new DeleteSampleServiceRequest(sample);

				var result = await handler.Handle(request, default);

				Assert.IsNotNull(result);
			}
		}
	}
}
