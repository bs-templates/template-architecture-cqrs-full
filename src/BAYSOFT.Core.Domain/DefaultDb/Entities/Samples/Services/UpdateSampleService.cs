using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Entity;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Validations;
using BAYSOFT.Core.Domain.DefaultDb.Interfaces.Infrastructures.Data;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Services
{
	public sealed class UpdateSampleServiceRequest : DomainServiceRequest<Sample>
	{
		public UpdateSampleServiceRequest(Sample payload) : base(payload)
		{
		}
	}
	public sealed class UpdateSampleServiceRequestHandler
		: DomainServiceRequestHandler<Sample, UpdateSampleServiceRequest>
	{
		private IDefaultDbContextWriter Writer { get; set; }
		public UpdateSampleServiceRequestHandler(
			IDefaultDbContextWriter writer,
			IStringLocalizer<Sample> localizer,
			SampleValidator entityValidator,
			UpdateSampleSpecificationsValidator domainValidator)
			: base(localizer, entityValidator, domainValidator)
		{
			Writer = writer;
		}
		public override async Task<Sample> Handle(
			UpdateSampleServiceRequest request,
			CancellationToken cancellationToken)
		{
			ValidateEntity(request.Payload);

			ValidateDomain(request.Payload);

			// Do the update

			return request.Payload;
		}
	}
}