using BAYSOFT.Abstractions.Core.Domain.Entities;
using BAYSOFT.Abstractions.Crosscutting.InheritStringLocalization;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Resources;
using BAYSOFT.Core.Domain.Default.Resources;
using BAYSOFT.Core.Domain.Resources;

namespace BAYSOFT.Core.Domain.Default.Aggregates.Samples.Entities
{
	[InheritStringLocalizer(typeof(Messages), Priority = 2)]
	[InheritStringLocalizer(typeof(ContextDefault), Priority = 1)]
	[InheritStringLocalizer(typeof(EntitySamples), Priority = 0)]
	public class Sample : DomainEntity<int>
    {
        public string Description { get; set; }
        public Sample()
        {
        }
    }
}
