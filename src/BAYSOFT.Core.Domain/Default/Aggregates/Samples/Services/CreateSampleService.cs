﻿using BAYSOFT.Abstractions.Core.Domain.Entities.Services;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Entities;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Resources;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Validations.DomainValidations;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Validations.EntityValidations;
using BAYSOFT.Core.Domain.Default.Interfaces.Infrastructures.Data;
using BAYSOFT.Core.Domain.Default.Resources;
using BAYSOFT.Core.Domain.Resources;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Default.Aggregates.Samples.Services
{
	public class CreateSampleServiceRequest : DomainServiceRequest<Sample>
	{
		public CreateSampleServiceRequest(Sample payload) : base(payload)
		{
		}
	}
	[InheritStringLocalizer(typeof(Messages), Priority = 0)]
	[InheritStringLocalizer(typeof(EntitiesDefault), Priority = 1)]
	[InheritStringLocalizer(typeof(EntitiesSamples), Priority = 2)]
	public class CreateSampleServiceRequestHandler
		: DomainServiceRequestHandler<Sample, CreateSampleServiceRequest>
	{
		private IDefaultDbContextWriter Writer { get; set; }
		public CreateSampleServiceRequestHandler(
			IDefaultDbContextWriter writer,
			IStringLocalizer<CreateSampleServiceRequestHandler> localizer,
			SampleValidator entityValidator,
			CreateSampleSpecificationsValidator domainValidator
		) : base(localizer, entityValidator, domainValidator)
		{
			Writer = writer;
		}
		public override async Task<Sample> Handle(CreateSampleServiceRequest request, CancellationToken cancellationToken)
		{
			ValidateEntity(request.Payload);

			ValidateDomain(request.Payload);

			await Writer.AddAsync(request.Payload);

			return request.Payload;
		}
	}
}