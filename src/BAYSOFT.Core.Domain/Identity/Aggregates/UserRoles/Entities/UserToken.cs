﻿using BAYSOFT.Abstractions.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BAYSOFT.Core.Domain.Identity.Aggregates.UserRoles.Entities
{
	public class UserToken : IdentityUserToken<string>, IDomainEntity<string>
	{
		public string Id { get; set; }
	}
}
