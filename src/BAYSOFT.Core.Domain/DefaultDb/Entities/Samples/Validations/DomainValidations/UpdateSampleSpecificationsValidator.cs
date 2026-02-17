using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Entity;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Specifications;

namespace BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Validations
{
    public sealed class UpdateSampleSpecificationsValidator : DomainValidator<Sample>
    {
        public UpdateSampleSpecificationsValidator(
            SampleDescriptionAlreadyExistsSpecification sampleDescriptionAlreadyExistsSpecification
        )
        {
            Add(
                nameof(sampleDescriptionAlreadyExistsSpecification),
                new DomainRule<Sample>(
                    sampleDescriptionAlreadyExistsSpecification.Not(),
                    sampleDescriptionAlreadyExistsSpecification.ToString()
                )
            );
        }
    }
}