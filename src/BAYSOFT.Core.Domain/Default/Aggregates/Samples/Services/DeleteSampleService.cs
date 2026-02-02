using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Entities;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Validations.DomainValidations;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Validations.EntityValidations;
using BAYSOFT.Core.Domain.Default.Interfaces.Infrastructures.Data;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Default.Aggregates.Samples.Services
{
	public class DeleteSampleServiceRequest : DomainServiceRequest<Sample>
	{
		public DeleteSampleServiceRequest(Sample payload) : base(payload)
		{
		}
	}
	public class DeleteSampleServiceRequestHandler
		: DomainServiceRequestHandler<Sample, DeleteSampleServiceRequest>
	{
		private IDefaultDbContextWriter Writer { get; set; }
		public DeleteSampleServiceRequestHandler(
			IDefaultDbContextWriter writer,
			IStringLocalizer<Sample> localizer,
			SampleValidator entityValidator,
			DeleteSampleSpecificationsValidator domainValidator
		) : base(localizer, entityValidator, domainValidator)
		{
			Writer = writer;
		}
		public override async Task<Sample> Handle(DeleteSampleServiceRequest request, CancellationToken cancellationToken)
		{
			ValidateEntity(request.Payload);

			ValidateDomain(request.Payload);

			Writer.Remove(request.Payload);

			return request.Payload;
		}
	}
}
