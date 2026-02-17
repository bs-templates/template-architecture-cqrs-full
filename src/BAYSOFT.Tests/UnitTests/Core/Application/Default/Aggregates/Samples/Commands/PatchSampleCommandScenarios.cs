using BAYSOFT.Core.Application.DefaultDb.Entities.Samples.Commands;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Entity;
using BAYSOFT.Infrastructures.Data.DefaultDb;
using BAYSOFT.Tests.Helpers;
using BAYSOFT.Tests.Helpers.Data.DefaultDb;
using BAYSOFT.Tests.Helpers.Data.DefaultDb.Samples;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;

namespace BAYSOFT.Tests.UnitTests.Core.Application.DefaultDb.Entities.Samples.Commands
{
	[TestClass]
	public class PatchSampleCommandScenarios
	{
		[TestMethod]
		public async Task PATCH_Sample_Should_Return_Ok()
		{
			var contextData = SamplesCollections.GetDefaultCollection();

			using (var context = DefaultDbContextExtensions.GetInMemoryDefaultDbContext().SetupSamples(contextData))
			{
				var writer = new DefaultDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var mockedMediator = new Mock<IMediator>();

				var localizer = GenericHelper.CreateLocalizer<Sample>();

				var handler = new PatchSampleCommandHandler(
					mockedLogger.Object,
					mockedMediator.Object,
					localizer,
					writer);

				var command = new PatchSampleCommand();

				command.Project(model =>
				{
					model.Id = SamplesCollections.FromInt(1);
					model.Description = "Sample - 001 [patch]";
				});

				var result = await handler.Handle(command, default);

				Assert.AreEqual((long)HttpStatusCode.OK, result.StatusCode);
			}
		}
	}
}
