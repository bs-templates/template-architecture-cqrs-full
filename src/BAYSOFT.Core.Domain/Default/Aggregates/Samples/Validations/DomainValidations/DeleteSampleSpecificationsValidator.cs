﻿using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Entities;

namespace BAYSOFT.Core.Domain.Default.Aggregates.Samples.Validations.DomainValidations
{
	public class DeleteSampleSpecificationsValidator : DomainValidator<Sample>
    {
        public DeleteSampleSpecificationsValidator()
        {
        }
    }
}
