using BAYSOFT.Abstractions.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BAYSOFT.Core.Domain.Identity.Aggregates.UserRoles.Entities
{
	public class UserClaim : IdentityUserClaim<string>, IDomainEntity<int>
	{
	}
}
