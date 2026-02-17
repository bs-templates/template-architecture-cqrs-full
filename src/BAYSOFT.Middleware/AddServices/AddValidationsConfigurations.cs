
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Specifications;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Validations;
using BAYSOFT.Core.Domain.DefaultDb.Entities.Samples.Validations.DomainValidations;
using Microsoft.Extensions.DependencyInjection;

namespace BAYSOFT.Middleware.AddServices
{
	public static class AddValidationsConfigurations
    {
        public static IServiceCollection AddSpecifications(this IServiceCollection services)
		{
			// Add Specifications
			services.AddTransient<SampleDescriptionAlreadyExistsSpecification>();

			return services;
        }
        public static IServiceCollection AddEntityValidations(this IServiceCollection services)
		{
            #region Validators of Default
            services.AddTransient<SampleValidator>();
            #endregion

			return services;
        }
        public static IServiceCollection AddDomainValidations(this IServiceCollection services)
		{
            #region Specifications Validators of Default
            services.AddTransient<UpdateSampleSpecificationsValidator>();
            services.AddTransient<CreateSampleSpecificationsValidator>();
            services.AddTransient<DeleteSampleSpecificationsValidator>();
            #endregion


			return services;
        }
    }
}
