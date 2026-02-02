using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Entities;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Specifications;

namespace BAYSOFT.Core.Domain.Default.Aggregates.Samples.Validations.DomainValidations
{
    public class DeleteSampleSpecificationsValidator : DomainValidator<Sample>
    {
        public DeleteSampleSpecificationsValidator(
            // SampleDescriptionAlreadyExistsSpecification sampleDescriptionAlreadyExistsSpecification
        )
        {
            // Add(
            //     nameof(sampleDescriptionAlreadyExistsSpecification),
            //     new DomainRule<Sample>(
            //         sampleDescriptionAlreadyExistsSpecification.Not(),
            //         sampleDescriptionAlreadyExistsSpecification.ToString()
            //     )
            // );
        }
    }
}