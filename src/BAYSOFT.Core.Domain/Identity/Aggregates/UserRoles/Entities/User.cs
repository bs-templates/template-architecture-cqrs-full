﻿using BAYSOFT.Abstractions.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BAYSOFT.Core.Domain.Identity.Aggregates.UserRoles.Entities
{
	public class User : IdentityUser, IDomainEntity<string>
	{
	}
}
