using BAYSOFT.Core.Application.DefaultDb.Entities.Samples.Notifications;
using BAYSOFT.Tests.Helpers;
using BAYSOFT.Tests.Helpers.Data.DefaultDb;
using BAYSOFT.Tests.Helpers.Data.DefaultDb.Samples;
using MediatR;
using Moq;

namespace BAYSOFT.Tests.UnitTests.Core.Application.DefaultDb.Entities.Samples.Notifications
{
	[TestClass]
	public class PatchSampleNotificationScenarios
	{
		[TestMethod]
		public async Task PatchSampleNotification_Should_Not_Return_Exception()
		{
			var contextData = SamplesCollections.GetDefaultCollection();

			using (var context = DefaultDbContextExtensions.GetInMemoryDefaultDbContext().SetupSamples(contextData))
			{
				var mockedLoggerFactory = GenericHelper.MockILoggerFactory<PatchSampleNotificationHandler>();

				var mockedMediator = new Mock<IMediator>();

				var handler = new PatchSampleNotificationHandler(
					mockedLoggerFactory.Object,
					mockedMediator.Object);

				var entity = contextData.First();

				var notification = new PatchSampleNotification(entity);

				await handler.Handle(notification, default);
			}
		}
	}
}
