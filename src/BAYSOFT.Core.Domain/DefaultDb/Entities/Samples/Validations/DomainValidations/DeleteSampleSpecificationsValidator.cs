//using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Specifications;
using BAYSOFT.Abstractions.Core.Domain.Entities.Validations;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Entity;

namespace BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Validations.DomainValidations
{
    public sealed class DeleteSampleSpecificationsValidator : DomainValidator<Sample>
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