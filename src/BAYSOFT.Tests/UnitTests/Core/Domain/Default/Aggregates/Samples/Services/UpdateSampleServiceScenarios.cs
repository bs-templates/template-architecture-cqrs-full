using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Entity;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Services;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Specifications;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Validations.DomainValidations;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Validations;
using BAYSOFT.Infrastructures.Data.DefaultDb;
using BAYSOFT.Tests.Helpers;
using BAYSOFT.Tests.Helpers.Data.DefaultDb;
using BAYSOFT.Tests.Helpers.Data.DefaultDb.Samples;

namespace BAYSOFT.Tests.UnitTests.Core.Domain.DefaultDb.Entities.Samples.Services
{
	[TestClass]
	public class UpdateSampleServiceScenarios
	{
		[TestMethod]
		public async Task UPDATE_Sample_Should_Not_Return_Exception()
		{
			var contextData = SamplesCollections.GetDefaultCollection();

			using (var context = DefaultDbContextExtensions.GetInMemoryDefaultDbContext().SetupSamples(contextData))
			{
				var reader = new DefaultDbContextReader(context);
				var writer = new DefaultDbContextWriter(context);

				var localizer = GenericHelper.CreateLocalizer<Sample>();

				var validator = new SampleValidator();
				var specification = new SampleDescriptionAlreadyExistsSpecification(reader);
				var specificationsValidator = new UpdateSampleSpecificationsValidator(specification);

				var handler = new UpdateSampleServiceRequestHandler(writer, localizer, validator, specificationsValidator);

				var sample = contextData.First();
				sample.Description += " [updated]";

				var request = new UpdateSampleServiceRequest(sample);

				var result = await handler.Handle(request, default);

				Assert.IsNotNull(result);
			}
		}
	}
}
