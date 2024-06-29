using BAYSOFT.Abstractions.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BAYSOFT.Core.Domain.Identity.Aggregates.UserRoles.Entities
{
	public class UserRole : IdentityUserRole<string>, IDomainEntity<string>
	{
		public string Id { get; set; }
	}
}
